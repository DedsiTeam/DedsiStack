using Dedsi.Ddd.CQRS;
using Volo.Abp.Modularity;

namespace DedsiAuthorization;

[DependsOn(
    typeof(DedsiDddCqrsModule)
)]
public class DedsiAuthorizationContractsModule: AbpModule;