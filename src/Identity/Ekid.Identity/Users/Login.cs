using Ekid.Identity.Users.Exceptions;

namespace Ekid.Identity.Users;

public sealed record Login
{
    public string Value { get; }
        
    public Login(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 3)
        {
            throw new InvalidLoginException(value);
        }
            
        Value = value;
    }

    public static implicit operator Login(string value) => new Login(value);

    public static implicit operator string(Login value) => value?.Value;

    public override string ToString() => Value;
}