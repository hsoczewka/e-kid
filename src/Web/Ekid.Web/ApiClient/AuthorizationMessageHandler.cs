using Ekid.Web.Auth;
using Ekid.Web.Models.Identity;
using Ekid.Web.Storage;

namespace Ekid.Web.ApiClient;

public sealed class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly ILocalStorage _localStorage;
    private readonly JwtAuthenticationStateProvider _authenticationStateProvider;

    public AuthorizationMessageHandler(ILocalStorage localStorage, JwtAuthenticationStateProvider authenticationStateProvider)
    {
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
    }
    
    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //var user = await _localStorage.GetItemAsync<User>("user");
        if (!string.IsNullOrWhiteSpace(_authenticationStateProvider.Token))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authenticationStateProvider.Token); 
        }
        return await base.SendAsync(request, cancellationToken); 
    }
}