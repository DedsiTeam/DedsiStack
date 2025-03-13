using Dedsi.Ddd.Domain.Queries;

namespace DedsiAuthorization.DedsiUsers.Queries;

public interface IContractDedsiUserQuery : IDedsiQuery
{
    /// <summary>
    /// 账号密码查询
    /// </summary>
    /// <param name="account"></param>
    /// <param name="accountPwd"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DedsiUser?> FindDedsiUserByAccountAsync(string account,string accountPwd,CancellationToken cancellationToken);
}