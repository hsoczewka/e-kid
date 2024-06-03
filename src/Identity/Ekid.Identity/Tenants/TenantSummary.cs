namespace Ekid.Identity.Tenants;

public record TenantSummary(Guid Id, string Name, string Description, bool IsActive)
{
    public static TenantSummary Create(Tenant tenant)
    {
        return new TenantSummary(Id: tenant.Id.Id, Name: tenant.Name, Description: tenant.Description,
            IsActive: tenant.IsActive);
    }
}