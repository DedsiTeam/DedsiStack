using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using Identity.EntityFrameworkCore;
using Identity.Users;
using Volo.Abp.EntityFrameworkCore;

namespace Identity.Repositories.Users;

public interface IUserRepository : IDedsiCqrsRepository<User, Guid>;

public class UserRepository(IDbContextProvider<IdentityDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<IdentityDbContext, User, Guid>(dbContextProvider),
        IUserRepository;