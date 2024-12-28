using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AuthorizationCenterManage;

[DependsOn(
    // AuthorizationCenterManage
    typeof(AuthorizationCenterManageDomainModule),
    typeof(AuthorizationCenterManageInfrastructureModule),
    
    typeof(DedsiDddCQRSModule)
)]
public class AuthorizationCenterManageUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}