using Ekid.Infrastructure.AppInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity.Users;

public static class Bootstrap
{
    public static void AddUsersComponents(this IServiceCollection services)
    {
        services.AddScoped<UserAccountRepository>();
        services.AddScoped<UserCredentialsRepository>();
        services.AddSingleton<IPasswordHasher<UserCredentials>, PasswordHasher<UserCredentials>>();
        services.RegisterComponentInitializer<UserAccountInitializer>();
    }
}