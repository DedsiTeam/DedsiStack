using Microsoft.EntityFrameworkCore;

namespace AuthorizationCenter.Host;

public class AuthorizationCenterDbContext(DbContextOptions<AuthorizationCenterDbContext> options) : DbContext(options);