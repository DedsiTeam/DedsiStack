using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Identity;

[DependsOn(
    // Identity
    typeof(IdentityDomainModule),
    typeof(IdentityInfrastructureModule),
    
    typeof(DedsiDddCQRSModule)
)]
public class IdentityUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}