namespace Ekid.Domain.Calendar;

public class Calendar
{
    private readonly List<Appointment> _appointments = new List<Appointment>();

    public void ScheduleAppointment(Guid attendeeId, Guid employeeId, Guid activityId, WeekDay day, DateTime startTime, DateTime endTime)
    {
        if (IsSlotAvailable(startTime, endTime, activityId, day))
        {
            _appointments.Add(new Appointment(
                attendeeId: attendeeId,
                activityId: activityId,
                employeeId: employeeId,
                weekDay: day,
                startTime: startTime,
                endTime: endTime));
        }
    }

    public void GetAppointments(Guid activityId, Guid employeeId, DateTime startDate, DateTime endDate)
    {
        
    }

    private bool IsSlotAvailable(DateTime startTime, DateTime endTime, Guid activityId, WeekDay day) 
    {
        foreach (var appointment in _appointments.Where(x => x.ActivityId == activityId && x.WeekDay == day)) 
        {
            if ((startTime >= appointment.StartTime && startTime < appointment.EndTime) ||
                (endTime > appointment.StartTime && endTime <= appointment.EndTime) ||
                (startTime <= appointment.StartTime && endTime >= appointment.EndTime)) {
                return false;
            }
        }
        return true;
    }
}