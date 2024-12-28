using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Identity;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class IdentityInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<IdentityDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}