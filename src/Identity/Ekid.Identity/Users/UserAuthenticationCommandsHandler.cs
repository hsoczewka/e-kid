using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Infrastructure.Messaging;
using Microsoft.AspNetCore.Identity;

namespace Ekid.Identity.Users;

public class UserAuthenticationCommandsHandler : ICommandHandler<SignUp>
{
    private readonly UserAccountRepository _userAccountRepository;
    private readonly IPasswordHasher<UserCredentials> _passwordHasher;
    private readonly UserCredentialsRepository _userCredentialsRepository;

    public UserAuthenticationCommandsHandler(UserAccountRepository userAccountRepository,
        IPasswordHasher<UserCredentials> passwordHasher,
        UserCredentialsRepository userCredentialsRepository)
    {
        _userAccountRepository = userAccountRepository;
        _passwordHasher = passwordHasher;
        _userCredentialsRepository = userCredentialsRepository;
    }

    public async Task HandleAsync(SignUp command, CancellationToken cancellationToken)
    {
        var email = new Email(command.Email);
        var userAccount = await _userAccountRepository.GetByEmailAsync(email, cancellationToken);
        if (userAccount is null)
            throw new Exception("User account does not exists. You are not allowed to sign up.");
        var userId = new UserId(userAccount.Id);
        var credentials = UserCredentials.Create(command, _passwordHasher, userId);

        var existsCredentials = await _userCredentialsRepository.FindAsync(credentials, cancellationToken);
        if (existsCredentials is null)
            await _userCredentialsRepository.AddAsync(credentials, cancellationToken);
        else
        {
            if (existsCredentials.Login == credentials.Login)
                throw new Exception("Login already in use");
            if (existsCredentials.Email == credentials.Email)
                throw new Exception("Email already in user.");
        }
    }
}