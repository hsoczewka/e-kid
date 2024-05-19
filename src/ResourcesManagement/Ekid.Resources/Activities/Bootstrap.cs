using Ekid.Resources.Activities.DAL;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Resources.Activities;

public static class Bootstrap
{
    public static void AddActivitiesComponents(this IServiceCollection services)
        => services.AddSingleton<InMemoryActivityRepository>();

    public static IEndpointRouteBuilder UseActivitiesEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints.UseActivityEndpoints();
}