using Ekid.Infrastructure.Http;
using Microsoft.AspNetCore.Http;

namespace Ekid.Infrastructure.CallContext;

internal class CallContextMiddleware : IMiddleware
{
    public const string TenantIdHeader = "Tenant-ID";

    private readonly CallContext _callContext;

    public CallContextMiddleware(CallContext callContext)
    {
        this._callContext = callContext;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        var user = httpContext.User;

        var endpoint = httpContext.GetEndpoint();
        var tenantIdRequired = endpoint?.Metadata.GetMetadata<TenantIdRequiredAttribute>();
        if (tenantIdRequired != null)
        {
            _callContext.TenantId = httpContext.ParseGuid(TenantIdHeader);
            if (_callContext.TenantId is null)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync($"{TenantIdHeader} value is required.");
                return;
            }
        }
        
        await next(httpContext);
    }
}