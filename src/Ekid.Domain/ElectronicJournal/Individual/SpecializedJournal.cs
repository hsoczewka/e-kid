namespace Ekid.Domain.ElectronicJournal.Individual;

public class SpecializedJournal
{
    public SpecializedJournal(Guid attendeeId, string description, string opinionNumber, string diagnosisResult)
    {
        AttendeeId = attendeeId;
        Description = description;
        OpinionNumber = opinionNumber;
        DiagnosisResult = diagnosisResult;
    }

    public Guid AttendeeId { get; }
    public string Description { get; }
    public string OpinionNumber { get; }
    public string DiagnosisResult { get; }
}