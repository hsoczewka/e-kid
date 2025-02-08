namespace Ekid.DigitalJournal.Journal;

public class JournalHeader
{
    public Guid Id { get; }
    public Guid TenantId { get; }
    public Guid PartyId { get; }
    public string JournalKind { get; } //EarlySupport, Specialized etc
    public DateTime CreatedAt { get; }
}