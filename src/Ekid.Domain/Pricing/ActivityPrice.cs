namespace Ekid.Domain.Pricing;

public class ActivityPrice
{
    public ActivityPrice(Guid id, Guid activityId, decimal price, DateTime from, DateTime? to)
    {
        Id = id;
        ActivityId = activityId;
        Price = price;
        From = from;
        To = to;
    }

    public Guid Id { get; }
    public Guid ActivityId { get; }
    public decimal Price { get; }
    public DateTime From { get; }
    public DateTime? To { get; }
}