using Ekid.Web.ApiClient;
using Ekid.Web.Auth;
using Ekid.Web.Storage;
using Ekid.Web.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Web;

public static class Bootstrap
{
    public static void AddWebCore(this IServiceCollection services)
    {
        services.AddAuthenticationStateComponents();
        services.AddScoped<ILocalStorage, LocalStorage>();
        services.AddScoped<IUserAccountClient, UserAccountClient>();
    }
    
}