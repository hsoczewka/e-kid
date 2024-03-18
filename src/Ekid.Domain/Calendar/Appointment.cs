namespace Ekid.Domain.Calendar;

public class Appointment
{
    public Appointment(Guid attendeeId, Guid activityId, Guid employeeId, DateTime startTime, DateTime endTime)
    {
        AttendeeId = attendeeId;
        ActivityId = activityId;
        EmployeeId = employeeId;
        StartTime = startTime;
        EndTime = endTime;
    }

    public Guid AttendeeId { get; }
    public Guid ActivityId { get; }
    public Guid EmployeeId { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
}