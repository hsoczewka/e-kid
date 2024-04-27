using Microsoft.AspNetCore.Http;

namespace Ekid.Infrastructure.CallContext;

internal class CallContextMiddleware
{
    public const string TenantIdHeader = "Tenant-ID";
    
    private readonly RequestDelegate next;

    public CallContextMiddleware(RequestDelegate next) => this.next = next;

    public async Task Invoke(HttpContext httpContext, CallContext callContext)
    {
        var user = httpContext.User;
        
        //TODO check if token is valid
        //set tenant id from header value
        
        await next(httpContext);
    }
}