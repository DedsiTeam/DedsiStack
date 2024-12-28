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
    Task<UserDto> GetByidAsync(Guid id, CancellationToken cancellationToken = default);
}

public class UserQuery(IDbContextProvider<IdentityDbContext> dbContextProvider)
    : DedsiEfCoreQuery<IdentityDbContext>(dbContextProvider),
        IUserQuery
{
    public async Task<UserDto> GetByidAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var userDbSet = await GetDbSetAsync<User>();
        
        var user = await userDbSet.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        return user.Adapt<UserDto>();
    }
}