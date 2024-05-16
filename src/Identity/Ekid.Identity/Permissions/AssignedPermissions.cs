namespace Ekid.Identity.Permissions;

public class AssignedPermissions
{
    public Guid UserId { get; set; }
    public Guid TenantId { get; set; }
    public List<Guid> Permissions { get; set; }
}