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
}