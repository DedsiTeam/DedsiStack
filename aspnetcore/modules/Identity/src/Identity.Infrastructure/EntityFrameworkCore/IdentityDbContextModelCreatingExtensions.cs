using Microsoft.EntityFrameworkCore;
using Identity.Users;
using Volo.Abp;

namespace Identity.EntityFrameworkCore;

public static class IdentityDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<User>(b =>
        {
            b.ToTable("Users", IdentityDomainOptions.DbSchemaName);
            b.HasKey(a => a.Id);
        });
    }
}