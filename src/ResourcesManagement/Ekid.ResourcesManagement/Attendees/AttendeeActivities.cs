namespace Ekid.ResourcesManagement.Attendees;

public class AttendeeActivities
{
    public AttendeeActivities(Guid id, Guid attendeeId, List<Guid> activities, List<IndividualPrice> individualPrices)
    {
        Id = id;
        AttendeeId = attendeeId;
        Activities = activities;
        IndividualPrices = individualPrices;
    }

    public Guid Id { get; }
    public Guid AttendeeId { get; }
    public List<Guid> Activities { get; }
    
    public List<IndividualPrice> IndividualPrices { get; } //find better way to override activity price
    
    //TODO include individual price model here
}