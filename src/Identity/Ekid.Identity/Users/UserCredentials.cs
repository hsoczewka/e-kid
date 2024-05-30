namespace Ekid.Identity.Users;

public class UserCredentials
{
    public UserId Id { get; private set; }
    public string Login { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    private int _version;
    
    public UserCredentials(UserId id, string login, string password, string email)
    {
        Id = id;
        Login = login;
        Password = password;
        Email = email;
    }
}