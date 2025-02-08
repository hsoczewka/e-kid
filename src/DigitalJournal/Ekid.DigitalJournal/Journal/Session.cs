using Ekid.Infrastructure.Primitives;

namespace Ekid.DigitalJournal.Journal;

//ActivitySession ? 
public class Session
{
    public Guid Id { get; }
    public Guid TenantId { get; }
    public Guid JournalHeaderId { get; }
    public Guid ActivityId { get; } //can be more than single activity on one session ?
    public Guid EmployeeId { get; }
    public TimeSlot TimeSlot { get; }
    // SessionKind | paid, free, grant
    //description ??
    //progress evaluation ??
    
    //maybe extract this to smth like common VO Session
    //and JournalSession will inherit from Session and extend with JournalHeaderId
    //the rest will be common
    //if we have session with AttendeeId we can find JournalHeaderId by AttendeeId
    //because Activity Session is part of Appointment/Calendar boundary 
    //so on the Journal UI we simply display sessions we did as a Journal record
    
}