using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace DedsiStack.EntityFrameworkCore;

public static class DedsiStackDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}