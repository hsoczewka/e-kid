namespace Ekid.Identity.Users.Exceptions;

public class InvalidRoleException : Exception
{
    public string Role { get; }

    public InvalidRoleException(string role) : base($"User role: '{role}' is invalid.")
    {
        Role = role;
    }
}