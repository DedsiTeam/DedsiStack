using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AuthorizationCenter.Host;


[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
public class AuthorizationCenterHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        context.Services
            .AddDbContext<AuthorizationCenterDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
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

                 options.RegisterScopes(OpenIddictConstants.Scopes.OpenId, OpenIddictConstants.Scopes.Email, OpenIddictConstants.Scopes.Profile, OpenIddictConstants.Scopes.Phone, OpenIddictConstants.Scopes.Roles, OpenIddictConstants.Scopes.Address, OpenIddictConstants.Scopes.OfflineAccess);

                 options
                     .AddDevelopmentEncryptionCertificate()
                     .AddDevelopmentSigningCertificate();

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