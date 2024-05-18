namespace Ekid.Infrastructure.Security;

public interface IPermissionRegistry
{
    public void ConfigurePermissions(PermissionContainer container);
}