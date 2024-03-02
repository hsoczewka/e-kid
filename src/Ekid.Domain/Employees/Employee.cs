namespace Ekid.Domain.Employees;

public class Employee
{
    public Employee(Guid id, string firstName, string lastName, string address, string idCard)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        IdCard = idCard;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public string IdCard { get; }
}