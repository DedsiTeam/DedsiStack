using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using DedsiAuthorization.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DedsiAuthorization;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class DedsiAuthorizationInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<DedsiAuthorizationDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}