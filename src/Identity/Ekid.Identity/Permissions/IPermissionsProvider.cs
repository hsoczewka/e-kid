namespace Ekid.Identity.Permissions;

public interface IPermissionsProvider
{
    Task<IReadOnlyCollection<Infrastructure.Security.Permission>> GetAvailablePermissions(
        CancellationToken cancellationToken);
}