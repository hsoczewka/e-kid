namespace Ekid.Domain.Employees;

public class EmployeeActivities
{
    public EmployeeActivities(Guid id, Guid employeeId, List<Guid> activities, List<string> roles)
    {
        Id = id;
        EmployeeId = employeeId;
        Activities = activities;
        Roles = roles;
    }

    public Guid Id { get; }
    public Guid EmployeeId { get; }
    public List<string> Roles { get; }
    public List<Guid> Activities { get; }
}