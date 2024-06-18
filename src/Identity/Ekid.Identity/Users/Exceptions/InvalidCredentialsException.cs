namespace Ekid.Identity.Users.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }
}