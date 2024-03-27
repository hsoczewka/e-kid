namespace Ekid.Domain.Attendees;

//Parent contact details
public class ContactDetails
{
    public Guid AttendeeId { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public string CorrespondenceAddress { get; }
}