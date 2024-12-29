using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using AuthorizationCenterManage.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AuthorizationCenterManage;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class AuthorizationCenterManageInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<AuthorizationCenterManageDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}