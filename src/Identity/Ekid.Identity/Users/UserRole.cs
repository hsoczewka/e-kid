using Ekid.Identity.Users.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Ekid.Identity.Users;

public sealed record UserRole
{
    public string Value { get; }

    private static IEnumerable<string> AvailableRoles { get; } =
        new[] { "User", "Administrator", "Employee" };
    
    public static UserRole Administrator => new UserRole(nameof(Administrator));
    public static UserRole User => new UserRole(nameof(User));
    public static UserRole Employee => new UserRole(nameof(Employee));

    public UserRole(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
        {
            throw new InvalidRoleException(value);
        }

        if (!AvailableRoles.Contains(value))
        {
            throw new InvalidRoleException(value);
        }

        Value = value;
    }
}