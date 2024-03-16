namespace Ekid.Domain.Calendar;

public class Calendar
{
    public List<Appointment> Appointments { get; }
    
    public Calendar(List<Appointment> appointments)
    {
        Appointments = appointments;
    }

    
}