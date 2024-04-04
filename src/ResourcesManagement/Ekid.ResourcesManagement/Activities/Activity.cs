using Ekid.Infrastructure.Primitives;

namespace Ekid.ResourcesManagement.Activities;

public class Activity
{
    public Activity(Guid id, string description, ActivityType type, TimeSpan duration, Money price)
    {
        Id = id;
        Description = description;
        Type = type;
        Duration = duration;
        Price = price;
    }

    public Guid Id { get; }
    public string Description { get; }
    public ActivityType Type { get; }
    public TimeSpan Duration { get; }
    public Money Price { get; }
}