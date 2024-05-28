using Ekid.Identity.Permissions;
using Ekid.Identity.Users;
using Ekid.Infrastructure.Storage;
using Ekid.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity;

public static class Bootstrap
{
    public static void AddIdentityComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPermissionsComponents();
        services.AddUsersComponents();
        services.AddPostgres<IdentityDbContext>(configuration);
        services.AddUnitOfWork<IdentityUnitOfWork>();
    }
}