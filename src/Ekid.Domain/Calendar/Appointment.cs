namespace Ekid.Domain.Calendar;

public class Appointment
{
    public Appointment(Guid attendeeId, Guid activityId, Guid employeeId, WeekDay weekDay, DateTime startTime, DateTime endTime)
    {
        AttendeeId = attendeeId;
        ActivityId = activityId;
        EmployeeId = employeeId;
        WeekDay = weekDay;
        StartTime = startTime;
        EndTime = endTime;
    }

    public Guid AttendeeId { get; }
    public Guid ActivityId { get; }
    public Guid EmployeeId { get; }
    public WeekDay WeekDay { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
}