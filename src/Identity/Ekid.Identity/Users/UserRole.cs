namespace Ekid.Identity.Users;

public record UserRole(string Value)
{
    public static UserRole Administrator => new UserRole(nameof(Administrator));
    public static UserRole User => new UserRole(nameof(User));
}