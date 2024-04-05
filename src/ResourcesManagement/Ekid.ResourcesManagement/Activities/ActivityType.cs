namespace Ekid.ResourcesManagement.Activities;

public record ActivityType(string Value)
{
    public static ActivityType Therapy => new ActivityType(nameof(Therapy));
    public static ActivityType Lesson => new ActivityType(nameof(Lesson));
    public static ActivityType Consultation => new ActivityType(nameof(Consultation));
    public static ActivityType Diagnosis => new ActivityType(nameof(Diagnosis));
    public static ActivityType SpeechTherapy => new ActivityType(nameof(SpeechTherapy));
    public static ActivityType SensoryIntegration => new ActivityType(nameof(SensoryIntegration));
}