using Dedsi.Ddd.Domain.Shared.EntityIds;
using Volo.Abp;

namespace DedsiAuthorization.DedsiUsers;

public class DedsiUserRole
{
    protected DedsiUserRole() {}
    
    /// <summary>
    /// 用户的角色构造函数
    /// </summary>
    /// <param name="userId">用户的Id</param>
    /// <param name="roleId">角色Id</param>
    /// <param name="roleName">角色名称</param>
    public DedsiUserRole(GuidStronglyTypedId userId, UlidStronglyTypedId roleId, string roleName)
    {
        ChangeUserId(userId);
        ChangeRoleId(roleId);
        ChangeRoleName(roleName);
    }
    
    /// <summary>
    /// 用户的Id
    /// </summary>
    public GuidStronglyTypedId UserId { get; private set; }
    
    /// <summary>
    /// 角色Id
    /// </summary>
    public UlidStronglyTypedId RoleId { get; private set; }
    
    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; private set; }

    /// <summary>
    /// 修改用户Id
    /// </summary>
    /// <param name="userId">新的用户Id</param>
    public void ChangeUserId(GuidStronglyTypedId userId)
    {
        UserId = Check.NotNull(userId, nameof(userId));
    }

    /// <summary>
    /// 修改角色Id
    /// </summary>
    /// <param name="roleId">新的角色Id</param>
    public void ChangeRoleId(UlidStronglyTypedId roleId)
    {
        RoleId = Check.NotNull(roleId, nameof(roleId));
    }

    /// <summary>
    /// 修改角色名称
    /// </summary>
    /// <param name="roleName">新的角色名称</param>
    public void ChangeRoleName(string roleName)
    {
        RoleName = Check.NotNullOrWhiteSpace(roleName, nameof(roleName));
    }
    
    public object?[] GetKeys()
    {
        return [UserId, RoleId];
    }
}