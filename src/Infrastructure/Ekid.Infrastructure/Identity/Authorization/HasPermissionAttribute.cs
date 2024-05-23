namespace Ekid.Infrastructure.Identity.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter | AttributeTargets.Method, AllowMultiple = true)]
public class HasPermissionAttribute(string permissionId) : Attribute
{
    public Guid RequiredPermission { get; } = new Guid(permissionId);
}