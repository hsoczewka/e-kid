namespace Ekid.Identity.Tenants;

public class Tenant
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsActive { get; }
    
    public Tenant(Guid id, string name, string description, bool isActive)
    {
        Id = id;
        Name = name;
        Description = description;
        IsActive = isActive;
    }
    
    //TODO
    //migration
    //initialize default tenant on startup
}