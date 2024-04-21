namespace Ekid.Infrastructure.Tenant;

public interface ITenant
{
    Guid TenantId { get; }
}