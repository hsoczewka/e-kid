using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Ekid.Web.Auth;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private static AuthenticationState NotAuthenticatedState = new AuthenticationState(new ClaimsPrincipal());

    private LoginUser? _user;

    /// <summary>
    /// The display name of the user.
    /// </summary>
    public string DisplayName => this._user?.DisplayName;

    /// <summary>
    /// <see langword="true"/> if there is a user logged in, otherwise false.
    /// </summary>
    public bool IsLoggedIn => this._user != null;

    /// <summary>
    /// The current JWT token or <see langword="null"/> if there is no user authenticated.
    /// </summary>
    public string Token => this._user?.Jwt;

    /// <summary>
    /// Login the user with a given JWT token.
    /// </summary>
    /// <param name="jwt">The JWT token.</param>
    public void Login(string jwt)
    {
        //instead try JwtSecurityTokenHandler.ReadToken
        var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
        var claimIdentity = new ClaimsIdentity(token.Claims, "jwt");
        var principal = new ClaimsPrincipal(new[] { claimIdentity });
        
        //var principal = JwtSerialize.Deserialize(jwt);
        this._user = new LoginUser(principal.Identity.Name, jwt, principal);
        this.NotifyAuthenticationStateChanged(Task.FromResult(GetState()));
    }

    /// <summary>
    /// Logout the current user.
    /// </summary>
    public void Logout()
    {
        this._user = null;
        this.NotifyAuthenticationStateChanged(Task.FromResult(GetState()));
    }

    /// <inheritdoc/>
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(GetState());
    }

    /// <summary>
    /// Constructs an authentication state.
    /// </summary>
    /// <returns>The created state.</returns>
    private AuthenticationState GetState()
    {
        if (this._user != null)
        {
            return new AuthenticationState(this._user.ClaimsPrincipal);
        }
        else
        {
            return NotAuthenticatedState;
        }
    }

    public class LoginUser
    {
        public LoginUser(string displayName, string jwt, ClaimsPrincipal claimsPrincipal)
        {
            ClaimsPrincipal = claimsPrincipal;
            DisplayName = displayName;
            Jwt = jwt;
        }

        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public string DisplayName { get; set; }
        public string Jwt { get; set; }
    }
}