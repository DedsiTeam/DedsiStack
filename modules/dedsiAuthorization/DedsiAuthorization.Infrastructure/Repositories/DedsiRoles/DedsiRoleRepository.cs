using Dedsi.Ddd.Domain.Repositories;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using Dedsi.EntityFrameworkCore.Repositories;
using DedsiAuthorization.DedsiRoles;
using DedsiAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DedsiAuthorization.Repositories.DedsiRoles;

public interface IDedsiRoleRepository : IDedsiCqrsRepository<DedsiRole, UlidStronglyTypedId>;

public class DedsiRoleRepository(IDbContextProvider<DedsiAuthorizationDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<DedsiAuthorizationDbContext, DedsiRole, UlidStronglyTypedId>(dbContextProvider),IDedsiRoleRepository;