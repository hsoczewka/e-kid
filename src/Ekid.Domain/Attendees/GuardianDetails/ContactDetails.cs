namespace Ekid.Domain.Attendees.GuardianDetails;

//Parent contact details
public class ContactDetails
{
    public ContactDetails(Guid id, List<Guid> attendeesIds, string phoneNumber, string email, string correspondenceAddress)
    {
        Id = id;
        AttendeesIds = attendeesIds;
        PhoneNumber = phoneNumber;
        Email = email;
        CorrespondenceAddress = correspondenceAddress;
    }

    public Guid Id { get; }
    public List<Guid> AttendeesIds { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public string CorrespondenceAddress { get; }
}