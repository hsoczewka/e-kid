namespace Ekid.Domain.Users;

public record UserRole(string Value)
{
    public static UserRole Employee => new UserRole(nameof(Employee));
    public static UserRole Administrator => new UserRole(nameof(Administrator));
    public static UserRole User => new UserRole(nameof(User));
}