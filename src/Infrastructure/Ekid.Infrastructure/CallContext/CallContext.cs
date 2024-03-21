namespace Ekid.Infrastructure.CallContext;

public class CallContext
{
    public CallContext(Guid correlationId, Guid userId)
    {
        CorrelationId = correlationId;
        UserId = userId;
    }

    public Guid CorrelationId { get; }
    public Guid UserId { get; }
}