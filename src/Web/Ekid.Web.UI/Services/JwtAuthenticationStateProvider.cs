using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Ekid.Web.UI.Services;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return new AuthenticationState(new ClaimsPrincipal());
    }
}