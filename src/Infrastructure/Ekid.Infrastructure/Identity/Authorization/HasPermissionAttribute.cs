namespace Ekid.Infrastructure.Identity.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = true)]
public class HasPermissionAttribute(string permissionId) : Attribute
{
    public Guid RequiredPermission { get; } = new Guid(permissionId);
}