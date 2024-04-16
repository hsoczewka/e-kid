using Ekid.Infrastructure.Primitives;

namespace Ekid.ResourcesManagement.Activities;

public class Activity
{
    public Activity(Guid id,
        string description,
        ActivityType type,
        TimeSpan duration,
        IReadOnlyCollection<ProductPrice> prices)
    {
        Id = id;
        Description = description;
        Type = type;
        Duration = duration;
        Prices = prices;
    }

    public Guid Id { get; }
    public string Description { get; }
    public ActivityType Type { get; }
    public TimeSpan Duration { get; }
    public IReadOnlyCollection<ProductPrice> Prices { get; }
}