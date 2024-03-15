namespace Ekid.Domain.Calendar;

public class Calendar
{
    public Guid AttendeeId { get; }
    public Guid ActivityId { get; }
    public Guid EmployeeId { get; }
    public WeekDay WeekDay { get; }
    public DateTime BeginTime { get; }
    public DateTime EndTime { get; }
}