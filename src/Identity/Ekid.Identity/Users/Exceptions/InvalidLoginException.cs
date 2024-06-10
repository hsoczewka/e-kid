namespace Ekid.Identity.Users.Exceptions;

public class InvalidLoginException : Exception
{
    public string Login { get; }

    public InvalidLoginException(string login) : base($"Login: '{login}' is invalid.")
    {
        Login = login;
    }
}