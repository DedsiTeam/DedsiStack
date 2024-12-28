using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace MicroserviceCenter.EntityFrameworkCore;

public static class MicroserviceCenterDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}