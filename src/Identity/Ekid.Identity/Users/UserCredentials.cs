using System.Runtime.CompilerServices;
using Ekid.Identity.Contracts.Users.Commands;
using Microsoft.AspNetCore.Identity;

namespace Ekid.Identity.Users;

public class UserCredentials
{
    public UserId Id { get; private set; }
    public Login Login { get; private set; }
    public Password Password { get; private set; }
    public Email Email { get; private set; }
    private int _version;
    
    public UserCredentials(UserId id, Login login, Password password, Email email)
    {
        Id = id;
        Login = login;
        Password = password;
        Email = email;
    }

    public static UserCredentials Create(SignUp command, IPasswordHasher<UserCredentials> passwordHasher, UserId id)
    {
        var password = new Password(command.Password);
        return new UserCredentials(id, 
            new Login(command.Login), 
            new Password(passwordHasher.HashPassword(default, password)),
            new Email(command.Email));
    }
}