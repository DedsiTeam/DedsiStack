using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DedsiStack;

[DependsOn(
    // DedsiStack
    typeof(DedsiStackDomainModule),
    typeof(DedsiStackInfrastructureModule),
    
    typeof(DedsiDddCqrsModule)
)]
public class DedsiStackUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}