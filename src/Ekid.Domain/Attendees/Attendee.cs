namespace Ekid.Domain.Attendees;

public class Attendee
{
    public Attendee(Guid id, string firstName, string lastName, string address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
}