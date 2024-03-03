namespace Ekid.Domain.Activities;

public class Activity
{
    public Activity(Guid id, string description, string type, int duration, decimal price)
    {
        Id = id;
        Description = description;
        Type = type;
        Duration = duration;
        Price = price;
    }

    public Guid Id { get; }
    public string Description { get; }
    public string Type { get; }
    public int Duration { get; }
    public decimal Price { get; }
}