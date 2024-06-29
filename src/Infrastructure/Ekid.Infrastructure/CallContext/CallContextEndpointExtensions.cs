using Microsoft.AspNetCore.Builder;

namespace Ekid.Infrastructure.CallContext;

public static class CallContextEndpointExtensions
{
    public static RouteHandlerBuilder RequireTenantId(this RouteHandlerBuilder builder)
    {
        builder.WithMetadata(new TenantIdRequiredAttribute());
        return builder;
    }
}