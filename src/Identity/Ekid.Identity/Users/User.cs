namespace Ekid.Identity.Users;

public class User
{
    public Guid Id { get; }
    public Guid TenantId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Login { get; }
    public string Password { get; }
    public string Email { get; }
    public UserRole Role { get; }
    public bool IsActive { get; }
    public int Version;
    
    public User(Guid id,
        Guid tenantId,
        string firstName,
        string lastName,
        string login,
        string password,
        string email,
        UserRole role,
        bool isActive)
    {
        Id = id;
        TenantId = tenantId;
        FirstName = firstName;
        LastName = lastName;
        Login = login;
        Password = password;
        Email = email;
        Role = role;
        IsActive = isActive;
    }
}