using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity.Users;

public static class Bootstrap
{
    public static void AddUsersComponents(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
    }
}