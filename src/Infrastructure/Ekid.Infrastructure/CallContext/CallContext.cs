using Ekid.Infrastructure.Tenant;

namespace Ekid.Infrastructure.CallContext;

public class CallContext
{
    public CallContext(Guid? tenantId, Guid correlationId, Guid userId)
    {
        TenantId = tenantId;
        CorrelationId = correlationId;
        UserId = userId;
    }

    public Guid? TenantId { get; internal set; }
    public Guid CorrelationId { get; internal set; }
    public Guid UserId { get; internal set; }
}