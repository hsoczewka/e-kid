namespace Ekid.Domain.Calendar;

public class Appointment
{
    public Appointment(Guid attendeeId, Guid activityId, Guid employeeId, WeekDay weekDay, DateTime beginTime, DateTime endTime)
    {
        AttendeeId = attendeeId;
        ActivityId = activityId;
        EmployeeId = employeeId;
        WeekDay = weekDay;
        BeginTime = beginTime;
        EndTime = endTime;
    }

    public Guid AttendeeId { get; }
    public Guid ActivityId { get; }
    public Guid EmployeeId { get; }
    public WeekDay WeekDay { get; }
    public DateTime BeginTime { get; }
    public DateTime EndTime { get; }
}