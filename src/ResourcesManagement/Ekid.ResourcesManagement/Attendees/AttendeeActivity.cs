using Ekid.Infrastructure.Primitives;

namespace Ekid.ResourcesManagement.Attendees;

public class AttendeeActivity
{
    public AttendeeActivity(Guid activityId, ProductPrice price)
    {
        ActivityId = activityId;
        Price = price;
    }

    public Guid ActivityId { get; }
    public ProductPrice Price { get; }
}