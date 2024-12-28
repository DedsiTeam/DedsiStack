using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Users;
using Volo.Abp.Data;

namespace Identity.EntityFrameworkCore;

[ConnectionStringName(IdentityDomainOptions.ConnectionStringName)]
public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : DedsiEfCoreDbContext<IdentityDbContext>(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}