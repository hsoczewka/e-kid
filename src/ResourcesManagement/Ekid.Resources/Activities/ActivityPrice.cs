using Ekid.Infrastructure.Primitives;

namespace Ekid.Resources.Activities;


//change name to PricePeriod ??
public class ActivityPrice
{
    public ActivityPrice(Guid id, Guid activityId, Money price, DateTime validFrom, DateTime? validTo)
    {
        Id = id;
        ActivityId = activityId;
        Price = price;
        ValidFrom = validFrom;
        ValidTo = validTo;
    }

    public Guid Id { get; set; }
    public Guid ActivityId { get; set; }
    public Money Price { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}