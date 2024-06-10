namespace Ekid.Identity.Users.Exceptions;

public sealed class InvalidEmailException : Exception
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }
}