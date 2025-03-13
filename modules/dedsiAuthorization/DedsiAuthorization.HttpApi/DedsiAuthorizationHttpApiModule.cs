using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DedsiAuthorization;

[DependsOn(
    typeof(DedsiAuthorizationUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class DedsiAuthorizationHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(DedsiAuthorizationHttpApiModule).Assembly);
        });
    }
}