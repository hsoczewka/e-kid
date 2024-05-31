namespace Ekid.Identity.Tenants;

public record TenantId(Guid Id)
{
    public static TenantId New() => new TenantId(Guid.NewGuid());
}