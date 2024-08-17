using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Ekid.Web.UI.Services;

public class CookieRequestHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        return await base.SendAsync(request, cancellationToken);
    }
}