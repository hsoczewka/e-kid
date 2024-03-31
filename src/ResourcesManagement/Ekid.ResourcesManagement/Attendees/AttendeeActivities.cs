namespace Ekid.ResourcesManagement.Attendees;

public class AttendeeActivities
{
    public AttendeeActivities(Guid id, Guid attendeeId, List<Guid> activities)
    {
        Id = id;
        AttendeeId = attendeeId;
        Activities = activities;
    }

    public Guid Id { get; }
    public Guid AttendeeId { get; }
    public List<Guid> Activities { get; }
}