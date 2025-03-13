using Dedsi.EntityFrameworkCore.Queries;
using DedsiAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DedsiAuthorization.DedsiUsers.Queries;

public class ContractDedsiUserQuery(IDbContextProvider<DedsiAuthorizationDbContext> dbContextProvider)
    : DedsiEfCoreQuery<DedsiAuthorizationDbContext>(dbContextProvider),IContractDedsiUserQuery;