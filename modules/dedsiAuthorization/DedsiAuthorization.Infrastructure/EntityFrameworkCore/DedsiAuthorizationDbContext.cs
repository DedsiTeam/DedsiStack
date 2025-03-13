using Dedsi.EntityFrameworkCore;
using DedsiAuthorization.DedsiRoles;
using DedsiAuthorization.DedsiUsers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace DedsiAuthorization.EntityFrameworkCore;

[ConnectionStringName(DedsiAuthorizationDomainOptions.ConnectionStringName)]
public class DedsiAuthorizationDbContext(DbContextOptions<DedsiAuthorizationDbContext> options) 
    : DedsiEfCoreDbContext<DedsiAuthorizationDbContext>(options)
{
    
    #region Dedsi Identity
    public DbSet<DedsiUser> DedsiUsers { get; set; }

    public DbSet<DedsiUserAccount> DedsiUserAccounts { get; set; }
    
    public DbSet<DedsiUserRole> DedsiUserRoles { get; set; }
    
    public DbSet<DedsiRole> DedsiRoles { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}