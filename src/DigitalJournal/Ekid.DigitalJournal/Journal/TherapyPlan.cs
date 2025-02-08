namespace Ekid.DigitalJournal.Journal;

public class TherapyPlan
{
    public Guid Id { get; }
    public Guid TenantId { get; }
    public Guid JournalHeaderId { get; }
    public string TherapeuticGoals { get; }
    public ICollection<PlannedActivity> PlannedActivities { get; }
    public string WorkingMethods { get; }
    
}

public record PlannedActivity(Guid ActivityId, int Hours);
//ActivityType ? 
//should be price fixed ?