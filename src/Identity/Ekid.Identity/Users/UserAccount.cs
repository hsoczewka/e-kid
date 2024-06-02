namespace Ekid.Identity.Users;

public class UserAccount
{
    public UserId Id { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserRole Role { get; private set; }
    public ISet<Guid> Tenants { get; private set; }
    public ISet<Guid> Permissions { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private int _version;
    
    public UserAccount(UserId id,
        string email,
        string firstName,
        string lastName,
        UserRole role,
        ISet<Guid> tenants,
        ISet<Guid> permissions,
        bool isActive,
        DateTime createdAt)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Tenants = tenants;
        IsActive = isActive;
        CreatedAt = createdAt;
        Permissions = permissions;
    }
    
    //Policies:
    //employee can belong to one tenant only
    //admin can belong to many tenants
    //user can belong to many tenants
    
}