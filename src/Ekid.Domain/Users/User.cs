namespace Ekid.Domain.Users;

public class User
{
    public User(Guid id,
        string firstName,
        string lastName,
        string login,
        string password,
        string email,
        List<string> roles,
        bool isActive)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Login = login;
        Password = password;
        Email = email;
        Roles = roles;
        IsActive = isActive;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Login { get; }
    public string Password { get; }
    public string Email { get; }
    public List<string> Roles { get; }
    public bool IsActive { get; }
}