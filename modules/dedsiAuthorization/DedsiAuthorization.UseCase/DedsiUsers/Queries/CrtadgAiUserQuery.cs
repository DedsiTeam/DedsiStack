using Dedsi.Ddd.Domain.Queries;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using Dedsi.EntityFrameworkCore.Queries;
using DedsiAuthorization.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DedsiAuthorization.DedsiUsers.Queries;

public interface ICrtadgAiUserQuery : IDedsiQuery
{
    /// <summary>
    /// 判断用户是否存在
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="pwd">加密后的密码</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserExistAsync(GuidStronglyTypedId userId,string pwd, CancellationToken cancellationToken);
}


public class CrtadgAiUserQuery(IDbContextProvider<DedsiAuthorizationDbContext> dbContextProvider)
    : DedsiEfCoreQuery<DedsiAuthorizationDbContext>(dbContextProvider), 
        ICrtadgAiUserQuery
{
    public async Task<bool> IsUserExistAsync(GuidStronglyTypedId userId, string pwd, CancellationToken cancellationToken)
    {
        var dbContext = await GetDbContextAsync();

        return await dbContext.DedsiUsers
            .Include(a => a.UserAccount)
            .AnyAsync(a => a.Id == userId && a.UserAccount.UserId == userId && a.UserAccount.AccountPwd == pwd, cancellationToken);
    }
}