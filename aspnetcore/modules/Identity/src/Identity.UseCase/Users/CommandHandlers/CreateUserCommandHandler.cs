﻿using Dedsi.Ddd.CQRS.CommandHandlers;
using Identity.Repositories.Users;
using Identity.Users.Commands;

namespace Identity.Users.CommandHandlers;

public class CreateUserCommandHandler(IUserRepository userRepository)
    : DedsiCommandHandler<CreateUserCommand, Guid>
{
    public override async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        // 创建用户
        var user = new User(GuidGenerator.Create(), command.UserName, command.Account, "PassWord@" + DateTime.Now.Year, command.Email);

        // 保存到数据库
        await userRepository.InsertAsync(user, cancellationToken: cancellationToken);

        return user.Id;
    }
}