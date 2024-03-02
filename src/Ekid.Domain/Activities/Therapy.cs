namespace Ekid.Domain.Activities;

public class Therapy
{
    public Therapy(Guid id, string name, string kind, string duration, decimal price)
    {
        Id = id;
        Name = name;
        Kind = kind;
        Duration = duration;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Kind { get; }
    public string Duration { get; }
    public decimal Price { get; }
}