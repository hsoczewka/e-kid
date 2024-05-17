namespace Ekid.Infrastructure.Security;

public abstract class PermissionContainer
{
    private readonly List<Permission> _permissions = [];
    
    protected void Configure(IEnumerable<Permission> permissions)
    {
        _permissions.AddRange(permissions);
    }

    public abstract void RegisterPermissions();
}