using Ekid.Identity.Permissions;
using Ekid.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity;

public static class Bootstrap
{
    public static void AddIdentityComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPermissionsComponents();
        services.AddPostgres<IdentityDbContext>(configuration);
    }
}