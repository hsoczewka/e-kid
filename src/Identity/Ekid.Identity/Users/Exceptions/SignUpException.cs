namespace Ekid.Identity.Users.Exceptions;

public class SignUpException : Exception
{
    private const string AccountNotExistsMessage = "User account does not exists. You are not allowed to sign up.";

    public SignUpException(string message) : base(message)
    {
    }

    public static SignUpException AccountNotExists()
        => new SignUpException(AccountNotExistsMessage);

    public static SignUpException CredentialsInUse(string credentialParameter)
    {
        return new SignUpException($"{credentialParameter} already in use.");
    }

}