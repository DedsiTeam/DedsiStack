using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace DedsiStack;

[DependsOn(
    // ProjectName
    typeof(DedsiStackHttpApiModule),

    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
public class DedsiStackHostModule : AbpModule
{
    
    private readonly string[] _useCaseModuleNames =
    [
        "DedsiAuthorization.UseCase"
    ];
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostEnvironment = context.Services.GetAbpHostEnvironment();

        // 数据库
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(dbConfigContext =>
            {
                // 本地研发环境 - 输出到控制台
                if (hostEnvironment.EnvironmentName == "Development")
                {
                    dbConfigContext.DbContextOptions.LogTo(Serilog.Log.Information, new[] { DbLoggerCategory.Database.Command.Name }).EnableSensitiveDataLogging();
                }
                dbConfigContext.UseMySQL();
            });
        });
        
        // 日志
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = DedsiStackDomainOptions.ApplicationName;
            options.IsEnabledForGetRequests = true;
        });
        
        // 时间格式 
        Configure<AbpJsonOptions>(options =>
        {
            options.OutputDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        });

        // 跨域
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? []
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // Swagger
        context.Services.AddSwaggerGen(options =>
        {
            options.DocInclusionPredicate((docName, description) => true);
            options.CustomSchemaIds(type => type.FullName);
            
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DedsiStack.HttpApi.xml"), true);
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DedsiStack.UseCase.xml"), true);
        });

        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(_useCaseModuleNames.Select(Assembly.Load).ToArray()));
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelExpandDepth(-1);
        });
        
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAuditing();

        app.UseConfiguredEndpoints(endpoints =>
        {
            // AuthorizeAttribute
            endpoints.MapControllers().RequireAuthorization();
        });

    }
}