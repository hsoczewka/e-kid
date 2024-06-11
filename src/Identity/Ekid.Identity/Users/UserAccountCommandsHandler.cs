using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Users;

public class UserAccountCommandsHandler : ICommandHandler<CreateUserAccount>
{
    private readonly UserRepository _userRepository;

    public UserAccountCommandsHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task HandleAsync(CreateUserAccount command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}