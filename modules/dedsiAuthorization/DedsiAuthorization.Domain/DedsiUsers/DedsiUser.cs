using Dedsi.Ddd.Domain.Shared.EntityIds;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DedsiAuthorization.DedsiUsers;

public class DedsiUser: Entity<GuidStronglyTypedId>
{
    protected DedsiUser()
    {

    }

    public DedsiUser(GuidStronglyTypedId id,string name): base(id)
    {
        ChangeName(name);
    }
    
    public string Name { get; private set; }

    public void ChangeName(string newName)
    {
        Name = Check.NotNullOrWhiteSpace(newName, nameof(newName));
    }
    
    /// <summary>
    /// 用户的账户
    /// </summary>
    public DedsiUserAccount UserAccount { get; private set; }

    public void CreateUserAccount(string account, string pwd)
    {
        UserAccount = new DedsiUserAccount(Id, account, pwd);
    }


    /// <summary>
    /// 用户的角色
    /// </summary>
    public ICollection<DedsiUserRole> UserRoles { get; private set; } = new List<DedsiUserRole>();
    
    public void AddUserRole(DedsiUserRole role)
    {
        UserRoles.Add(role);
    }
}