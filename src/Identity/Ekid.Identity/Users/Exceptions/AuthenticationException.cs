namespace Ekid.Identity.Users.Exceptions;

public class AuthenticationException : Exception
{
    private const string AccountNotExistsMessage = "User account does not exists. You are not allowed to authenticate.";

    public AuthenticationException(string message) : base(message)
    {
    }

    public static AuthenticationException AccountNotExists()
        => new AuthenticationException(AccountNotExistsMessage);

    public static AuthenticationException CredentialsInUse(string credentialParameter)
    {
        return new AuthenticationException($"{credentialParameter} already in use.");
    }

}