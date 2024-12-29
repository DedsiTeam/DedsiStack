using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace AuthorizationCenterManage.EntityFrameworkCore;

[ConnectionStringName(AuthorizationCenterManageDomainOptions.ConnectionStringName)]
public class AuthorizationCenterManageDbContext(DbContextOptions<AuthorizationCenterManageDbContext> options) 
    : DedsiEfCoreDbContext<AuthorizationCenterManageDbContext>(options)
{


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}