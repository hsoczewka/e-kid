namespace Ekid.Domain.Employees;

public class EmployeeActivities
{
    public EmployeeActivities(Guid id, Guid employeeId, List<Guid> activities)
    {
        Id = id;
        EmployeeId = employeeId;
        Activities = activities;
    }

    public Guid Id { get; }
    public Guid EmployeeId { get; }
    public List<Guid> Activities { get; }
}