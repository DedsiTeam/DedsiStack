using Dedsi.Ddd.CQRS.CommandHandlers;
using Dedsi.Ddd.CQRS.Commands;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using DedsiAuthorization.Repositories.DedsiUsers;
using FluentValidation;
using Volo.Abp.Security.Encryption;

namespace DedsiAuthorization.DedsiUsers.CommandHandlers;

public record CreateDedsiUserCommand(string Name, string Account, string Pwd): DedsiCommand<DedsiUser>;

public class CreateDedsiUserCommandValidator : AbstractValidator<CreateDedsiUserCommand>
{
    public CreateDedsiUserCommandValidator()
    {
        RuleFor(x => x.Name).Length(2, 10);
    }
}

/// <summary>
/// 创建用户
/// </summary>
/// <param name="stringEncryptionService"></param>
/// <param name="crtadgAiUserRepository"></param>
public class CreateDedsiUserCommandHandler(
    IStringEncryptionService stringEncryptionService,
    IDedsiUserRepository crtadgAiUserRepository)
    : DedsiCommandHandler<CreateDedsiUserCommand, DedsiUser>
{
    public override async Task<DedsiUser> Handle(CreateDedsiUserCommand command, CancellationToken cancellationToken)
    {
        var crtadgAiUserId = new GuidStronglyTypedId(GuidGenerator.Create());
        var crtadgAiUser = new DedsiUser(crtadgAiUserId, command.Name);

        // 密码加密：使用当前的 crtadgAiUserId
        var pwdEncrypt = stringEncryptionService.Encrypt(command.Pwd, command.Account)!;
        crtadgAiUser.CreateUserAccount(command.Account, pwdEncrypt);

        // 保存数据库
        await crtadgAiUserRepository.InsertAsync(crtadgAiUser, false, cancellationToken);
        
        return crtadgAiUser;
    }
}