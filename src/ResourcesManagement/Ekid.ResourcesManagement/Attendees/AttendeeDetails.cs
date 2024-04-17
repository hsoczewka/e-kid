namespace Ekid.ResourcesManagement.Attendees;

public class AttendeeDetails
{
    public AttendeeDetails(string firstName,
        string lastName,
        string address,
        string birthPlace,
        DateTime birtDateTime)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        BirthPlace = birthPlace;
        BirtDateTime = birtDateTime;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public string BirthPlace { get; }
    public DateTime BirtDateTime { get; }
}