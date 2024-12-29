using Identity;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace AuthorizationCenter.Host;


[DependsOn(
    // Identity
    typeof(IdentityUseCaseModule),
    
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
public class AuthorizationCenterHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        context.Services
            .AddDbContext<AuthorizationCenterDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AuthorizationCenterDB"));
                options.UseOpenIddict();
            });

        context.Services
             .AddOpenIddict()
             .AddCore(options =>
             {
                 options.UseEntityFrameworkCore().UseDbContext<AuthorizationCenterDbContext>();
             })
             .AddServer(options =>
             {

                 options
                     .SetAuthorizationEndpointUris("connect/authorize", "connect/authorize/callback")
                     .SetDeviceAuthorizationEndpointUris("device")
                     .SetIntrospectionEndpointUris("connect/introspect")
                     .SetEndSessionEndpointUris("connect/endsession")
                     .SetRevocationEndpointUris("connect/revocat")
                     .SetTokenEndpointUris("connect/token")
                     .SetUserInfoEndpointUris("connect/userinfo")
                     .SetEndUserVerificationEndpointUris("connect/verify");

                 options
                     .AllowAuthorizationCodeFlow()
                     .AllowHybridFlow()
                     .AllowImplicitFlow()
                     .AllowPasswordFlow()
                     .AllowClientCredentialsFlow()
                     .AllowRefreshTokenFlow()
                     .AllowDeviceAuthorizationFlow()
                     .AllowNoneFlow();

                 options
                     .AddDevelopmentEncryptionCertificate()
                     .AddDevelopmentSigningCertificate();

                 // 禁用加密
                 // options.DisableAccessTokenEncryption();

                 options.UseAspNetCore()
                     .EnableAuthorizationEndpointPassthrough()
                     .EnableTokenEndpointPassthrough()
                     .EnableUserInfoEndpointPassthrough()
                     .EnableEndSessionEndpointPassthrough()
                     .EnableEndUserVerificationEndpointPassthrough()
                     .EnableStatusCodePagesIntegration()
                     .DisableTransportSecurityRequirement();
             });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.UseDeveloperExceptionPage();
        
        app.UseRouting();
        app.UseCors();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseConfiguredEndpoints();
    }
}