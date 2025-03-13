using DedsiAuthorization.Openiddict.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace DedsiAuthorization.Openiddict;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
)]
public class DedsiAuthorizationOpeniddictModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services
            .AddOpenIddict()
            .AddCore(options =>
            {
                options.UseEntityFrameworkCore().UseDbContext<CrtadgAiAuthorizationOpeniddictDbContext>();
            })
            .AddServer(options =>
            {
                options.SetTokenEndpointUris("connect/token");

                options
                    .AllowClientCredentialsFlow()
                    .AllowPasswordFlow();

                options
                    .AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate();

                options
                    .UseAspNetCore()
                    .DisableTransportSecurityRequirement()
                    .EnableTokenEndpointPassthrough();
            });
    }
}