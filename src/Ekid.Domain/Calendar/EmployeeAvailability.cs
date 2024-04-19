using Ekid.Infrastructure.Primitives;

namespace Ekid.Domain.Calendar;

public class EmployeeAvailability
{
    public Guid EmployeeId { get; }
    public List<TimeSlot> TimeSlots { get; }
}

//employee availability plan
//plan can be created automatically for given period: week/month
//automatically created plan should be in draft status waiting for employee approval
//after plan is approved can be used for appointment activities