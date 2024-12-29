using Microsoft.EntityFrameworkCore;

namespace AuthorizationCenterManage.EntityFrameworkCore;

/// <summary>
/// 给 OpenIddict 使用
/// </summary>
/// <param name="options"></param>
public class OpenIddictEfCoreDbContext(DbContextOptions<OpenIddictEfCoreDbContext> options) : DbContext(options);