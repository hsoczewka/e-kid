namespace Ekid.Infrastructure.Auth;

public class JsonWebToken
{
    public string AccessToken { get; set; }
    public long Expiry { get; set; }
    public Guid UserId { get; set; }
}