using DedsiAuthorization.DedsiUsers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace DedsiAuthorization.EntityFrameworkCore;

public static class AbpEntityOptionExtensions
{
    public static void ConfigureAbpDefaultWithDetails(this AbpEntityOptions options)
    {
        options.Entity<DedsiUser>(abpEntityOptions =>
        {
            abpEntityOptions.DefaultWithDetailsFunc = query => query.Include(o => o.UserAccount);
        });
    }
}