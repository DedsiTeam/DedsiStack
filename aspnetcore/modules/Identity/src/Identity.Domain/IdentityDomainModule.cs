using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace Identity;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class IdentityDomainModule : AbpModule;