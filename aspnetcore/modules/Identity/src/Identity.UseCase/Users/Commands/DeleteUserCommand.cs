using Dedsi.Ddd.CQRS.Commands;

namespace Identity.Users.Commands;

public record DeleteUserCommand(Guid id) : DedsiCommand<bool>;
