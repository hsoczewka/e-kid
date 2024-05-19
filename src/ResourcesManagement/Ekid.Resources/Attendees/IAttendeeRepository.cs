namespace Ekid.Resources.Attendees;

public interface IAttendeeRepository
{
    Task SaveAsync(Attendee attendee, CancellationToken cancellationToken);
    Task GetAsync(Guid id, CancellationToken cancellationToken);
}