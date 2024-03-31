using System.Runtime.InteropServices.JavaScript;

namespace Ekid.Domain.Calendar;

public class Calendar
{
    private readonly List<Appointment> _appointments = new List<Appointment>();

    public void ScheduleAppointment(Guid attendeeId, Guid employeeId, Guid activityId, DateTime startTime, DateTime endTime)
    {
        if (IsSlotAvailable(startTime, endTime, activityId))
        {
            _appointments.Add(new Appointment(
                attendeeId: attendeeId,
                activityId: activityId,
                employeeId: employeeId,
                startTime: startTime,
                endTime: endTime));
        }
    }

    public IReadOnlyCollection<Appointment> GetAppointments(Guid activityId, Guid employeeId, DateTime startDate, DateTime endDate)
    {
        return _appointments.Where(x => x.ActivityId == activityId
                                         && x.EmployeeId == employeeId
                                         && x.StartTime >= startDate
                                         && x.EndTime <= endDate).ToList();
    }

    public IReadOnlyCollection<Appointment> GetEmployeeAppointments(Guid employeeId, DateTime startDate, DateTime endDate)
    {
        return _appointments.Where(x => x.EmployeeId == employeeId
                                        && x.StartTime >= startDate
                                        && x.EndTime <= endDate).ToList();
    }
    
    public IReadOnlyCollection<Appointment> GetAttendeeAppointments(Guid attendeeId, DateTime startDate, DateTime endDate)
    {
        return _appointments.Where(x => x.AttendeeId == attendeeId
                                        && x.StartTime >= startDate
                                        && x.EndTime <= endDate).ToList();
    }

    private bool IsSlotAvailable(DateTime startTime, DateTime endTime, Guid activityId)
    {
        foreach (var appointment in _appointments.Where(x => x.ActivityId == activityId)) 
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