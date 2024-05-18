using Ekid.Infrastructure.Security;

namespace Ekid.Identity.Permissions;

public class PermissionsProvider : IPermissionsProvider
{
    private readonly PermissionContainer _container;

    public PermissionsProvider(PermissionContainer container)
    {
        _container = container;
    }

    public Task<IReadOnlyCollection<Infrastructure.Security.Permission>> GetAvailablePermissions(
        CancellationToken cancellationToken)
    {
        return Task.FromResult(_container.Permissions);
    }
}