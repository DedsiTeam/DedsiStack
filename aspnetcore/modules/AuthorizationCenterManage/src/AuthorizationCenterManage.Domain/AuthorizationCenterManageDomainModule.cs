using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace AuthorizationCenterManage;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class AuthorizationCenterManageDomainModule : AbpModule
{
    
}