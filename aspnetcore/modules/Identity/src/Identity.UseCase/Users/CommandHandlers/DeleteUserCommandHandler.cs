using Dedsi.Ddd.CQRS.CommandHandlers;
using Identity.Repositories.Users;
using Identity.Users.Commands;
using Identity.Users.Queries;

namespace Identity.Users.CommandHandlers;

public class DeleteUserCommandHandler(IUserRepository userRepository, IUserQuery userQuery) : DedsiCommandHandler<DeleteUserCommand, bool>
{
    public override async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await userRepository.DeleteAsync(a => a.Id == command.id, false, cancellationToken);
        return true;
    }
}
