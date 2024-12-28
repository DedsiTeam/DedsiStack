using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AuthorizationCenterManage.EntityFrameworkCore;

public static class AuthorizationCenterManageDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}