using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Web.Auth;

public static class Bootstrap
{
    public static void AddAuthenticationStateComponents(this IServiceCollection services)
    {
        services.AddScoped<JwtAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());
    }
}