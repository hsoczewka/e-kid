using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Users;

public class CreateUserCommandHandler : ICommandHandler<CreateUser>
{
    public Task HandleAsync(CreateUser command)
    {
        throw new NotImplementedException();
    }
}