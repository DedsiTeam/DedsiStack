﻿using Dedsi.Ddd.CQRS.CommandHandlers;
using Identity.Repositories.Users;
using Identity.Users.Commands;
using Volo.Abp;

namespace Identity.Users.CommandHandlers;

public class UpdateUserCommandHandler(IUserRepository userRepository) : DedsiCommandHandler<UpdateUserCommand, bool>
{
    public override async Task<bool> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(a => a.Id == command.id, cancellationToken: cancellationToken);
        if (user == null)
        {
            throw new UserFriendlyException("数据不存在！");
        }

        user.ChangeAccount(command.Account);
        user.ChangeEmail(command.Email);
        user.ChangeUserName(command.UserName);

        await userRepository.UpdateAsync(user, cancellationToken: cancellationToken);

        return true;
    }
}