using Dedsi.Ddd.CQRS;
using Volo.Abp.Modularity;

namespace DedsiAuthorization;

[DependsOn(
    // DedsiAuthorization
    typeof(DedsiAuthorizationDomainModule),
    typeof(DedsiAuthorizationInfrastructureModule),
    
    // DedsiAuthorization Contracts
    typeof(DedsiAuthorizationContractsModule),
    
    typeof(DedsiDddCqrsModule)
)]
public class DedsiAuthorizationUseCaseModule : AbpModule;