using Dedsi.Ddd.Domain.Shared.EntityIds;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DedsiAuthorization.DedsiUsers;

public class DedsiUserAccount: IEntity
{
    protected DedsiUserAccount()
    {
        
    }

    public DedsiUserAccount(GuidStronglyTypedId userId, string account, string accountPwd)
    {
        UserId = userId;
        ChangeAccount(account);
        ChangeAccountPwd(accountPwd);
    }
    
    public GuidStronglyTypedId UserId { get; private set; }

    /// <summary>
    /// 账户
    /// </summary>
    public string Account { get; private set; }

    public void ChangeAccount(string newAccount)
    {
        Account = Check.NotNullOrWhiteSpace(newAccount, nameof(newAccount));
    }
    
    /// <summary>
    /// 账户的密码
    /// </summary>
    public string AccountPwd { get; private set; }

    public void ChangeAccountPwd(string newAccountPwd)
    {
        AccountPwd = Check.NotNullOrWhiteSpace(newAccountPwd, nameof(newAccountPwd));
    }

    public object?[] GetKeys()
    {
        return [ UserId, Account ];
    }
}