using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Identity.Users.Exceptions;
using Ekid.Infrastructure.Auth;
using Ekid.Infrastructure.Messaging;
using Microsoft.AspNetCore.Identity;

namespace Ekid.Identity.Users;

public class UserAuthenticationCommandsHandler : 
    ICommandHandler<SignUp>, 
    ICommandHandler<SignIn>
{
    private readonly UserAccountRepository _userAccountRepository;
    private readonly IPasswordHasher<UserCredentials> _passwordHasher;
    private readonly UserCredentialsRepository _userCredentialsRepository;
    private readonly IAuthTokenGenerator _tokenGenerator;

    public UserAuthenticationCommandsHandler(UserAccountRepository userAccountRepository,
        IPasswordHasher<UserCredentials> passwordHasher,
        UserCredentialsRepository userCredentialsRepository, 
        IAuthTokenGenerator tokenGenerator)
    {
        _userAccountRepository = userAccountRepository;
        _passwordHasher = passwordHasher;
        _userCredentialsRepository = userCredentialsRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task HandleAsync(SignUp command, CancellationToken cancellationToken)
    {
        var email = new Email(command.Email);
        var userAccount = await _userAccountRepository.GetByEmailAsync(email, cancellationToken);
        if (userAccount is null)
            throw AuthenticationException.AccountNotExists();
        var userId = new UserId(userAccount.Id);
        var credentials = UserCredentials.Create(command, _passwordHasher, userId);

        var existsCredentials = await _userCredentialsRepository.FindAsync(credentials, cancellationToken);
        if (existsCredentials is null)
            await _userCredentialsRepository.AddAsync(credentials, cancellationToken);
        else
        {
            if (existsCredentials.Login == credentials.Login)
                throw AuthenticationException.CredentialsInUse("Login");
            if (existsCredentials.Email == credentials.Email)
                throw AuthenticationException.CredentialsInUse("Email");
        }
    }

    public async Task HandleAsync(SignIn command, CancellationToken cancellationToken)
    {
        var userCredentials = await _userCredentialsRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (userCredentials is null)
            throw new InvalidCredentialsException();

        if (_passwordHasher.VerifyHashedPassword(userCredentials, userCredentials.Password, command.Password) !=
            PasswordVerificationResult.Success)
            throw new InvalidCredentialsException();

        var userAccount = await _userAccountRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (userAccount is null)
            throw AuthenticationException.AccountNotExists();
        
        var jwt = _tokenGenerator.CreateToken(userCredentials.Id.Id, userAccount.Role);
        command.Token = new UserAccessToken(AccessToken: jwt.AccessToken);
    }
}