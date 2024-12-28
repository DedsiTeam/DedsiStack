using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MicroserviceCenter;

[DependsOn(
    typeof(MicroserviceCenterUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class MicroserviceCenterHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MicroserviceCenterHttpApiModule).Assembly);
        });
    }

}