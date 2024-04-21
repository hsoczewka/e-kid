using Ekid.Infrastructure.Primitives;
using Ekid.Infrastructure.Tenant;

namespace Ekid.ResourcesManagement.Activities;

public class Activity : ITenant
{
    public Activity(Guid id,
        Guid tenantId,
        string description,
        ActivityType type,
        TimeSpan duration,
        IEnumerable<ProductPrice> prices)
    {
        Id = id;
        TenantId = tenantId;
        Description = description;
        Type = type;
        Duration = duration;
        Prices = prices;
        
    }

    public Guid Id { get; }
    public Guid TenantId { get; }
    public string Description { get; }
    public ActivityType Type { get; }
    public TimeSpan Duration { get; }
    public IEnumerable<ProductPrice> Prices { get; }
    
}