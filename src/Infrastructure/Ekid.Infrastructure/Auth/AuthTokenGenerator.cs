using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ekid.Infrastructure.Auth;

internal sealed class AuthTokenGenerator : IAuthTokenGenerator
{
    private readonly TimeProvider _timeProvider;
    private readonly JwtSecurityTokenHandler _jwtSecurityToken = new JwtSecurityTokenHandler();
    private readonly AuthOptions _authOptions;

    public AuthTokenGenerator(TimeProvider timeProvider, IOptionsMonitor<AuthOptions> optionsMonitor)
    {
        _timeProvider = timeProvider;
        _authOptions = optionsMonitor.CurrentValue;
    }

    public JsonWebToken CreateToken(Guid userId, string role)
    {
        var now = _timeProvider.GetLocalNow();
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new Claim(ClaimTypes.Role, role),
        };
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SigningKey)),
                SecurityAlgorithms.HmacSha256);
        
        var expires = now.Add(_authOptions.Expiry ?? TimeSpan.FromHours(1));
        var securityToken = new JwtSecurityToken(_authOptions.Issuer, _authOptions.Audience, claims, now.DateTime,
            expires.DateTime, signingCredentials);
        var token = _jwtSecurityToken.WriteToken(securityToken);
        
        return new JsonWebToken()
        {
            AccessToken = token,
            Expiry = expires.Ticks,
            UserId = userId
        };
    }
}