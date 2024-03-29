namespace Ekid.Domain.ElectronicJournal.Individual;

public class SpecializedJournal
{
    public SpecializedJournal(Guid id, Guid attendeeId, string description, string opinionNumber, string diagnosisResult, List<Guid> employeesIds)
    {
        Id = id;
        AttendeeId = attendeeId;
        Description = description;
        OpinionNumber = opinionNumber;
        DiagnosisResult = diagnosisResult;
        EmployeesIds = employeesIds;
    }

    public Guid Id;
    public Guid AttendeeId { get; }
    public string Description { get; }
    public string OpinionNumber { get; }
    public string DiagnosisResult { get; }
    public List<Guid> EmployeesIds { get; }
}