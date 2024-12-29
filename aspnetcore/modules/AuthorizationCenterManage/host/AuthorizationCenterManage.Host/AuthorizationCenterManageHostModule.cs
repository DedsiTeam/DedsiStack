using AuthorizationCenterManage.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Validation.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace AuthorizationCenterManage;

[DependsOn(
    // ProjectName
    typeof(AuthorizationCenterManageHttpApiModule),

    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
public class AuthorizationCenterManageHostModule : AbpModule
{
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
                dbConfigContext.UseSqlServer();
            });
        });

        #region OpenIddict
        context.Services.AddDbContext<OpenIddictEfCoreDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
            options.UseOpenIddict();
        });
        
        context.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        });


        context.Services
            .AddOpenIddict()
            .AddCore(options =>
            {
                options
                    .UseEntityFrameworkCore()
                    .UseDbContext<OpenIddictEfCoreDbContext>();
            })
            .AddValidation(options =>
            {
                options.SetIssuer("http://localhost:10086/");
                // options.AddAudiences("BookStore");
                
                options.UseIntrospection()
                    .SetClientId("AuthorizationCenterManage.Host")
                    .SetClientSecret("FFA8E1D2-9A97-BFBF-865A-3A1722D3F3BD");

                options.UseSystemNetHttp();

                options.UseAspNetCore();
            });

        #endregion

        
        // 日志
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = AuthorizationCenterManageDomainOptions.ApplicationName;
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
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "AuthorizationCenterManage.HttpApi.xml"), true);
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "AuthorizationCenterManage.UseCase.xml"), true);
        });

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