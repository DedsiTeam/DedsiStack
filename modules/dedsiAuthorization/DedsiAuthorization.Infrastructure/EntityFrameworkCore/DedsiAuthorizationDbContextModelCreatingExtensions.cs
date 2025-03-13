using DedsiAuthorization.DedsiRoles;
using DedsiAuthorization.DedsiUsers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace DedsiAuthorization.EntityFrameworkCore;

public static class DedsiAuthorizationDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        
        #region DedsiUser

        builder.Entity<DedsiUser>(b =>
        {
            b.ToTable("DedsiUsers", DedsiAuthorizationDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);

            // 一对一
            b.HasOne(e => e.UserAccount)
                .WithOne()
                .HasForeignKey<DedsiUserAccount>(e => e.UserId)
                .IsRequired();

            // 一对多
            b.HasMany(e => e.UserRoles)
                .WithOne()
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(a => a.UserId)
                .IsRequired();
        });

        builder.Entity<DedsiUserAccount>(b =>
        {
            b.ToTable("DedsiUserAccounts", DedsiAuthorizationDomainOptions.DbSchemaName);
            b.HasKey(x => new { x.UserId, x.Account });
        });

        builder.Entity<DedsiUserRole>(b =>
        {
            b.ToTable("DedsiUserRoles", DedsiAuthorizationDomainOptions.DbSchemaName);
            b.HasKey(x => new { x.UserId, x.RoleId });
        });
        
        builder.Entity<DedsiRole>(b =>
        {
            b.ToTable("DedsiRoles", DedsiAuthorizationDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);
        });
        #endregion
    }
}