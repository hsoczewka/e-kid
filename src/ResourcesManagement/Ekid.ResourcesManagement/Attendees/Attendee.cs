using Ekid.ResourcesManagement.Activities;

namespace Ekid.ResourcesManagement.Attendees;

public class Attendee
{
    public Attendee(Guid id, AttendeeDetails details, IEnumerable<AttendeeActivity> activities)
    {
        Id = id;
        Details = details;
        Activities = activities;
    }

    public Guid Id { get; }
    //TODO ContactId => ContactDetails
    public AttendeeDetails Details { get; }
    public IEnumerable<AttendeeActivity> Activities { get; }
}