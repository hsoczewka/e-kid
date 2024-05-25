namespace Ekid.Identity.Permissions;

public class AssignedPermissions
{
    public Guid UserId { get; set; }
    public Guid TenantId { get; set; }
    public ICollection<Guid> Permissions { get; set; }
    
    public AssignedPermissions(Guid userId, Guid tenantId, ICollection<Guid> permissions)
    {
        UserId = userId;
        TenantId = tenantId;
        Permissions = permissions;
    }
}