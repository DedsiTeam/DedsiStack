using Dedsi.Ddd.Domain.Queries;
using Dedsi.EntityFrameworkCore.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Identity.EntityFrameworkCore;
using Identity.Users.Dtos;
using Volo.Abp.EntityFrameworkCore;

namespace Identity.Users.Queries;

public interface IUserQuery : IDedsiQuery
{
    /// <summary>
    /// 主键Id查询
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserDto> GetByidAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <param name="passWord"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserDto> GetByAccountAndPwdAsync(string? account, string? passWord, CancellationToken cancellationToken);
}

public class UserQuery(IDbContextProvider<IdentityDbContext> dbContextProvider)
    : DedsiEfCoreQuery<IdentityDbContext>(dbContextProvider),
        IUserQuery
{
    public async Task<UserDto> GetByidAsync(Guid id, CancellationToken cancellationToken)
    {
        var userDbSet = await GetDbSetAsync<User>();
        
        var user = await userDbSet.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        return user.Adapt<UserDto>();
    }

    public async Task<UserDto> GetByAccountAndPwdAsync(string? account, string? passWord, CancellationToken cancellationToken)
    {
        var userDbSet = await GetDbSetAsync<User>();
        
        var user = await userDbSet.FirstOrDefaultAsync(a => a.Account == account && a.PassWord == passWord, cancellationToken);

        return user.Adapt<UserDto>();
    }
}