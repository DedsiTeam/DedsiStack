using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace DedsiAuthorization;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class DedsiAuthorizationDomainModule : AbpModule;