using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DedsiStack;

[DependsOn(
    typeof(DedsiStackUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class DedsiStackHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(DedsiStackHttpApiModule).Assembly);
        });
    }
}