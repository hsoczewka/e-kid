using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Identity.Users.Exceptions;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Users;

public class UserAccountCommandsHandler : ICommandHandler<CreateUserAccount>
{
    private readonly UserRepository _userRepository;

    public UserAccountCommandsHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(CreateUserAccount command, CancellationToken cancellationToken)
    {
        var userAccount = UserAccount.Create(command);
        if (await _userRepository.GetByEmailAsync(userAccount.Email, cancellationToken) is not null)
        {
            throw new EmailAlreadyInUseException(userAccount.Email);
        }

        await _userRepository.AddAsync(userAccount, cancellationToken);
    }
}