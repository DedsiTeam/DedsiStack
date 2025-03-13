using Dedsi.Ddd.CQRS.CommandHandlers;
using Dedsi.Ddd.CQRS.Commands;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using DedsiAuthorization.DedsiUsers;
using DedsiAuthorization.Repositories.DedsiUsers;
using Volo.Abp.Security.Encryption;

namespace DedsiAuthorization.DedsiUsers.CommandHandlers;

/// <summary>
/// 设置为默认密码：返回密码原文
/// </summary>
/// <param name="CrtadgAiUserId">用户的Id</param>
public record SetDefaultPwdCommand(GuidStronglyTypedId CrtadgAiUserId): DedsiCommand<string>;

/// <summary>
/// 将用户的密码设置为默认密码
/// </summary>
/// <param name="stringEncryptionService"></param>
/// <param name="dedsiUserRepository"></param>
public class SetDefaultPwdCommandHandler(
    IStringEncryptionService stringEncryptionService,
    IDedsiUserRepository dedsiUserRepository) 
    : DedsiCommandHandler<SetDefaultPwdCommand, string>
{
    public override async Task<string> Handle(SetDefaultPwdCommand command, CancellationToken cancellationToken)
    {
        var crtadgAiUser = await dedsiUserRepository.GetAsync(a => a.Id == command.CrtadgAiUserId, true, cancellationToken);
        if (crtadgAiUser == null)
        {
            throw new ArgumentException("用户不存在");
        }
        var pwdEncrypt = stringEncryptionService.Encrypt(DedsiUserConsts.CrtadgAiUserDefaultPwd, crtadgAiUser.UserAccount.Account)!;
        crtadgAiUser.UserAccount.ChangeAccountPwd(pwdEncrypt);
        
        // 修改用户密码
        await dedsiUserRepository.UpdateAsync(crtadgAiUser, false, cancellationToken);
        
        return DedsiUserConsts.CrtadgAiUserDefaultPwd;
    }
}