namespace Ekid.Domain.Attendees;

public class Document
{
    public Document(Guid id, string documentType, Guid attendeeId)
    {
        Id = id;
        DocumentType = documentType;
        AttendeeId = attendeeId;
    }

    public Guid Id { get; }
    public string DocumentType { get; }
    public Guid AttendeeId { get; }
}