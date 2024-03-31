namespace Ekid.ResourcesManagement.Attendees;

public class Attendee
{
    public Attendee(Guid id, string firstName, string lastName, string address, string birthPlace, DateTime birtDateTime)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        BirthPlace = birthPlace;
        BirtDateTime = birtDateTime;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public string BirthPlace { get; }
    public DateTime BirtDateTime { get; }
}