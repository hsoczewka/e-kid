namespace Ekid.Domain.Calendar;

public class EmployeeAvailability
{
    public Guid EmployeeId { get; }
    public DateTime AvailableFrom { get; }
    public DateTime AvailableTo { get; }
}