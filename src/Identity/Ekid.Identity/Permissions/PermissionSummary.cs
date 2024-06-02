namespace Ekid.Identity.Permissions;

public class PermissionSummary
{
    public PermissionSummary(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}