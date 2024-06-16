using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Identity.Users.Exceptions;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Users;

public class UserAccountCommandsHandler : ICommandHandler<CreateUserAccount>
{
    private readonly UserAccountRepository _userAccountRepository;

    public UserAccountCommandsHandler(UserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public async Task HandleAsync(CreateUserAccount command, CancellationToken cancellationToken)
    {
        var userAccount = UserAccount.Create(command);
        if (await _userAccountRepository.GetByEmailAsync(userAccount.Email, cancellationToken) is not null)
        {
            throw new EmailAlreadyInUseException(userAccount.Email);
        }

        await _userAccountRepository.AddAsync(userAccount, cancellationToken);
    }
}