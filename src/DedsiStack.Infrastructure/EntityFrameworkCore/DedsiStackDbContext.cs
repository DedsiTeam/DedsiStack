using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace DedsiStack.EntityFrameworkCore;

[ConnectionStringName(DedsiStackDomainOptions.ConnectionStringName)]
public class DedsiStackDbContext(DbContextOptions<DedsiStackDbContext> options) 
    : DedsiEfCoreDbContext<DedsiStackDbContext>(options)
{

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}