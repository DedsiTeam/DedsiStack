using Dedsi.Ddd.CQRS.CommandHandlers;
using Dedsi.Ddd.CQRS.Commands;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using DedsiAuthorization.Repositories.DedsiUsers;
using FluentValidation;

namespace DedsiAuthorization.DedsiUsers.CommandHandlers;

/// <summary>
/// 修改账户的密码
/// </summary>
/// <param name="UserId"></param>
/// <param name="OldPwd">加密后的旧密码</param>
/// <param name="NewPwd">加密后的新密码</param>
public record UpdatePwdCommand(GuidStronglyTypedId UserId,string OldPwd, string NewPwd): DedsiCommand<bool>;


public class UpdatePwdCommandValidator: AbstractValidator<UpdatePwdCommand>
{
    public UpdatePwdCommandValidator()
    {

    }
}

/// <summary>
/// 修改用户的密码
/// </summary>
/// <param name="dedsiUserRepository"></param>
public class UpdatePwdCommandHandler(IDedsiUserRepository dedsiUserRepository) : DedsiCommandHandler<UpdatePwdCommand, bool>
{
    public override async Task<bool> Handle(UpdatePwdCommand command, CancellationToken cancellationToken)
    {
        var crtadgAiUser = await dedsiUserRepository.GetAsync(a => a.Id == command.UserId && a.UserAccount.AccountPwd == command.OldPwd, true, cancellationToken);
        if (crtadgAiUser == null)
        {
            throw new NullReferenceException("找不到用户！");
        }
        
        crtadgAiUser.UserAccount.ChangeAccountPwd(command.NewPwd);
        
        // 修改用户密码
        await dedsiUserRepository.UpdateAsync(crtadgAiUser, false, cancellationToken);

        return true;
    }
}