using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace MicroserviceCenter.EntityFrameworkCore;

[ConnectionStringName(MicroserviceCenterDomainOptions.ConnectionStringName)]
public class MicroserviceCenterDbContext(DbContextOptions<MicroserviceCenterDbContext> options) 
    : DedsiEfCoreDbContext<MicroserviceCenterDbContext>(options)
{


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}