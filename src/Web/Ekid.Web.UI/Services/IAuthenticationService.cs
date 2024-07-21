using Ekid.Web.Models.Identity;

namespace Ekid.Web.UI.Services;

public interface IAuthenticationService
{
    User User { get; }
    Task InitializeAsync();
    Task<bool?> SignInAsync(string email, string password);
    Task SignOutAsync();
}

public class AuthenticationService : IAuthenticationService
{
    public User User { get; private set; }
    
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task<bool?> SignInAsync(string email, string password)
    {
        return false;
    }

    public Task SignOutAsync()
    {
        return Task.CompletedTask;
    }
}