using Ekid.Identity.Contracts.Users.Commands;

namespace Ekid.Identity.Users;

public class UserAccount
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserRole Role { get; private set; }
    public ISet<Guid> Tenants { get; private set; }
    public ISet<Guid> Permissions { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private int _version;
    
    public UserAccount(UserId id,
        Email email,
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

    public static UserAccount Create(CreateUserAccount command)
    {
        var role = new UserRole(command.Role);
        if (command.Tenants != null && role.Value == UserRole.Employee.Value && command.Tenants.Count != 1)
        {
            throw new Exception($"User with role '{role.Value}' can belongs to one tenant only.");
        }

        return new UserAccount(id: UserId.New(), email: new Email(command.Email), firstName: command.FirstName,
            lastName: command.LastName, role: role, tenants: command.Tenants ?? new HashSet<Guid>(), permissions: command.Permissions ?? new HashSet<Guid>(),
            isActive: true, createdAt: DateTime.UtcNow);

    }
    
}