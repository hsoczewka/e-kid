using Microsoft.AspNetCore.Builder;

namespace Ekid.Infrastructure.CallContext;

public static class Bootstrap
{
    public static void AddCallContextComponents(this IServiceCollection services)
    {
        services.AddScoped(_ => CallContext.Empty());
        services.AddScoped<CallContextMiddleware>();
    }

    public static void UseCallContext(this WebApplication app)
    {
        app.UseMiddleware<CallContextMiddleware>();
    }
}