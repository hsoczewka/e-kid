using Ekid.Infrastructure.Security;

namespace Ekid.Identity.Contracts.Security;

public class Permissions : IPermissionRegistry
{
    public const string ViewPermissionsId = "8876c5f2-d9d1-4a83-9674-c32dc586ed74";
    public const string ManagePermissionsId = "876b9890-56d4-4262-ab73-26db6e38a56a";

    public static Permission ViewPermissions => new Permission("View Permissions", Guid.Parse(ViewPermissionsId));
    public static Permission ManagePermissions => new Permission("Manage Permissions", Guid.Parse(ManagePermissionsId));

    public void ConfigurePermissions(PermissionContainer container)
        => container.Register(new[] { ViewPermissions, ManagePermissions });
}