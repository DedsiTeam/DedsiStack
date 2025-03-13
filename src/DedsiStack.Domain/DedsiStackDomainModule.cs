using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace DedsiStack;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class DedsiStackDomainModule : AbpModule;