using Dedsi.Ddd.Domain.Shared.EntityIds;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DedsiAuthorization.DedsiRoles;

public class DedsiRole: Entity<UlidStronglyTypedId>
{
    
    protected DedsiRole()
    {
        
    }
    
    public DedsiRole(UlidStronglyTypedId id, string roleName, string description) : base(id)
    {
        ChangeRoleName(roleName);
        ChangeDescription(description);
    }
    
    public string RoleName { get; protected set; }

    public void ChangeRoleName(string newRoleName)
    {
        RoleName = Check.NotNullOrWhiteSpace(newRoleName, nameof(newRoleName));
    }
    
    public string Description { get; protected set; }

    public void ChangeDescription(string newDescription)
    {
        Description = Check.NotNullOrWhiteSpace(newDescription, nameof(newDescription));
    }
}