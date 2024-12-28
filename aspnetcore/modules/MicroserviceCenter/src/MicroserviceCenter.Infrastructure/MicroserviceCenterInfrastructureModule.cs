using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MicroserviceCenter.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MicroserviceCenter;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class MicroserviceCenterInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<MicroserviceCenterDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}