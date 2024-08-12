using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Web.ApiClient;

public static class Bootstrap
{
    public static void AddApiClientComponents<TCookieHandler>(this IServiceCollection services)
        where TCookieHandler : DelegatingHandler
    {
        services.AddHttpClient("Ekid.Api", client => { client.BaseAddress = new Uri("http://localhost:5185"); })
            .AddHttpMessageHandler<AuthorizationMessageHandler>()
            .AddHttpMessageHandler<TCookieHandler>();
        services.AddTransient<AuthorizationMessageHandler>();
        services.AddTransient<TCookieHandler>();
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Ekid.Api"));
        services.AddScoped<CustomHttpClient>();
    }
}