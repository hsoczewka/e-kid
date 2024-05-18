namespace Ekid.Infrastructure.Security;

public class PermissionContainer
{
    private readonly List<Permission> _permissions = new();

    public IReadOnlyCollection<Permission> Permissions => _permissions;
    
    internal PermissionContainer() { }
    
    public PermissionContainer Register(IEnumerable<Permission> permissions)
    {
        //TODO validation of already existing permission
        _permissions.AddRange(permissions);
        return this;
    }
}