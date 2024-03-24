namespace Ekid.Domain.Communication;

public class NotificationsBoard
{
    public Guid Id { get; }
    public string Title { get; }
    public string Message { get; }
    public Guid UserId { get; }
    public DateTime CreatedAt { get; }
}