using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace MicroserviceCenter;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class MicroserviceCenterDomainModule : AbpModule
{
    
}