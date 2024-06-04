namespace Ekid.Identity.Tenants;

public class Tenant
{
    public TenantId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsActive { get; private set; }
    
    public Tenant(TenantId id, string name, string description, bool isActive)
    {
        Id = id;
        Name = name;
        Description = description;
        IsActive = isActive;
    }

    public void Activate() => IsActive = true;

    //TODO
    //migration
    //initialize default tenant on startup
}