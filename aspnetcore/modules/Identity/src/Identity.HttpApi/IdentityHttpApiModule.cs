using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Identity;

[DependsOn(
    typeof(IdentityUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class IdentityHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(IdentityHttpApiModule).Assembly);
        });
    }

}