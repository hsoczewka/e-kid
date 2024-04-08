using Ekid.Infrastructure.Primitives;

namespace Ekid.ResourcesManagement.Attendees;

public class IndividualPrice
{
    public Guid ActivityId { get; }
    public Money Price { get; }
    public DateTime ValidFrom { get; }
    public DateTime? ValidTo { get; }
}