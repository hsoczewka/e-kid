namespace Ekid.Infrastructure.Auth;

public interface IAuthTokenGenerator
{
    JsonWebToken CreateToken(Guid userId, string role);
}