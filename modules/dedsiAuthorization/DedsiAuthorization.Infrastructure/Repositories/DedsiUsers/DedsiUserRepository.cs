using Dedsi.Ddd.Domain.Repositories;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using Dedsi.EntityFrameworkCore.Repositories;
using DedsiAuthorization.DedsiUsers;
using DedsiAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DedsiAuthorization.Repositories.DedsiUsers;

public interface IDedsiUserRepository : IDedsiCqrsRepository<DedsiUser, GuidStronglyTypedId>;

public class DedsiUserRepository(IDbContextProvider<DedsiAuthorizationDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<DedsiAuthorizationDbContext, DedsiUser, GuidStronglyTypedId>(dbContextProvider),IDedsiUserRepository;