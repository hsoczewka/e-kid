namespace Ekid.Resources.Attendees;

public class Attendee
{
    public Attendee(Guid id, Guid contactId, AttendeeDetails details, IEnumerable<AttendeeActivity> activities)
    {
        Id = id;
        Details = details;
        Activities = activities;
        ContactId = contactId;
    }

    public Guid Id { get; }
    public Guid ContactId { get; }
    public AttendeeDetails Details { get; }
    public IEnumerable<AttendeeActivity> Activities { get; }
}