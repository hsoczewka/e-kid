using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ekid.Infrastructure.Auth;

public static class Bootstrap
{
    private const string AuthSectionName = "auth";
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.GetOptions<AuthOptions>(AuthSectionName);

        services.Configure<AuthOptions>(configuration.GetRequiredSection(AuthSectionName));
        services.AddSingleton<IAuthTokenGenerator, AuthTokenGenerator>();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.Audience = authOptions.Audience;
            o.IncludeErrorDetails = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authOptions.Issuer,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SigningKey))
            };
        });
        
        services.AddAuthorizationBuilder()
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());
    }
}