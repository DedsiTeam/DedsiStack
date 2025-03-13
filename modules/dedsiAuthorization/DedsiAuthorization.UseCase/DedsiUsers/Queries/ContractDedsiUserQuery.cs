using Dedsi.EntityFrameworkCore.Queries;
using DedsiAuthorization.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DedsiAuthorization.DedsiUsers.Queries;

public class ContractDedsiUserQuery(IDbContextProvider<DedsiAuthorizationDbContext> dbContextProvider)
    : DedsiEfCoreQuery<DedsiAuthorizationDbContext>(dbContextProvider),IContractDedsiUserQuery
{
    /// <inheritdoc />
    public async Task<DedsiUser?> FindDedsiUserByAccountAsync(string account, string accountPwd, CancellationToken cancellationToken)
    {
        var dbContext = await GetDbContextAsync();

        return await dbContext.DedsiUsers
            .AsNoTracking()
            .Include(a => a.UserAccount)
            .Where(a => a.UserAccount.Account == account && a.UserAccount.AccountPwd == accountPwd)
            .FirstOrDefaultAsync(cancellationToken);
    }
}