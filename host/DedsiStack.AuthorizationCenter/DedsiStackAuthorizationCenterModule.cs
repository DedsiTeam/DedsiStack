using System.Reflection;
using DedsiAuthorization.Openiddict;
using Microsoft.EntityFrameworkCore;
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
    typeof(DedsiAuthorizationOpeniddictModule),
    
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
public class DedsiStackAuthorizationCenterModule: AbpModule
{
    
    private readonly string[] _useCaseModuleNames =
    [
        "DedsiAuthorization.UseCase"
    ];
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostEnvironment = context.Services.GetAbpHostEnvironment();

        // 数据库
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(dbConfigContext =>
            {
                // 本地研发环境 - 输出到控制台
                if (hostEnvironment.EnvironmentName == "Development")
                {
                    dbConfigContext.DbContextOptions
                        .LogTo(Serilog.Log.Information, [DbLoggerCategory.Database.Command.Name])
                        .EnableSensitiveDataLogging();
                }
                dbConfigContext.UseMySQL();
            });
        });

        // 日志
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = DedsiStackAuthorizationCenterConsts.ApplicationName;
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
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(_useCaseModuleNames.Select(Assembly.Load).ToArray()));
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAuditing();
        
        app.UseConfiguredEndpoints(options =>
        {
            options.MapDefaultControllerRoute();
        });
    }
}