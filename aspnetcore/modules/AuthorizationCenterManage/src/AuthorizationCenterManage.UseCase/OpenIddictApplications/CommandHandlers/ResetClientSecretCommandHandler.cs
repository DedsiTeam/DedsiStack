using AuthorizationCenterManage.OpenIddictApplications.Commands;
using Dedsi.Ddd.CQRS.CommandHandlers;
using OpenIddict.Abstractions;
using Volo.Abp;

namespace AuthorizationCenterManage.OpenIddictApplications.CommandHandlers;

/// <summary>
/// 重置客户端的 客户端密钥
/// </summary>
/// <param name="openIddictApplicationManager"></param>
public class ResetClientSecretCommandHandler(IOpenIddictApplicationManager openIddictApplicationManager): DedsiCommandHandler<ResetClientSecretCommand, string>
{
    /// <inheritdoc />
    public override async Task<string> Handle(ResetClientSecretCommand command, CancellationToken cancellationToken)
    {
        var openIddictApplication = await openIddictApplicationManager.FindByClientIdAsync(command.ClientId, cancellationToken);
        if (openIddictApplication == null)
        {
            throw new UserFriendlyException("应用不存在");
        }
        
        var clientSecret = GuidGenerator.Create().ToString().ToUpper();
        await openIddictApplicationManager.UpdateAsync(openIddictApplication, clientSecret, cancellationToken);

        return clientSecret;
    }
}