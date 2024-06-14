namespace Ekid.Identity.Users.Exceptions;

public class InvalidRoleAssigmentException : Exception
{
    public string Role { get; }

    public InvalidRoleAssigmentException(string role) : base($"User with role '{role}' can belongs to one tenant only.")
    {
        Role = role;
    }
    
}