using Ekid.Infrastructure.Primitives;

namespace Ekid.Domain.Calendar;

public class EmployeeAvailability
{
    public Guid EmployeeId { get; }
    public List<TimeSlot> TimeSlots { get; }
}