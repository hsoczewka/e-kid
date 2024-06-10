namespace Ekid.Identity.Users.Exceptions;

public sealed class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}