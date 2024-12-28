using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MicroserviceCenter;

[DependsOn(
    // MicroserviceCenter
    typeof(MicroserviceCenterDomainModule),
    typeof(MicroserviceCenterInfrastructureModule),
    
    typeof(DedsiDddCQRSModule)
)]
public class MicroserviceCenterUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}