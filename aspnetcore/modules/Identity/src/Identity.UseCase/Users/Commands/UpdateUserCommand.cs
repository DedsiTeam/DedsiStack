﻿using Dedsi.Ddd.CQRS.Commands;

namespace Identity.Users.Commands;

public record UpdateUserCommand(Guid id,string UserName, string Account, string Email) : DedsiCommand<bool>;
