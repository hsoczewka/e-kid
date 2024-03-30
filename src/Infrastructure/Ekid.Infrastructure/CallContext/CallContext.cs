namespace Ekid.Infrastructure.CallContext;

public class CallContext
{
    public CallContext(Guid tenantId, Guid correlationId, Guid userId)
    {
        TenantId = tenantId;
        CorrelationId = correlationId;
        UserId = userId;
    }

    public Guid TenantId { get; }
    public Guid CorrelationId { get; }
    public Guid UserId { get; }
}