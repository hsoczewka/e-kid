using Ekid.Web.Models.Identity;
using Ekid.Web.Storage;
using Ekid.Web.Users;
using Microsoft.AspNetCore.Components;

namespace Ekid.Web.UI.Services;

public interface IAuthenticationService
{
    User User { get; }
    Task InitializeAsync();
    Task<bool?> LoginAsync(string email, string password);
    Task SignUpAsync(string login, string email, string password);
    Task SignOutAsync();
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserAccountClient _accountClient;
    private readonly ILocalStorage _localStorage;
    private readonly NavigationManager _navigationManager;

    public AuthenticationService(
        IUserAccountClient accountClient, 
        ILocalStorage localStorage, 
        NavigationManager navigationManager)
    {
        _accountClient = accountClient;
        _localStorage = localStorage;
        _navigationManager = navigationManager;
    }

    public User User { get; private set; }
    
    public async Task InitializeAsync()
    {
        User = await _localStorage.GetItemAsync<User>("user");
    }

    public async Task<bool?> LoginAsync(string email, string password)
    {
        return false;
    }

    public Task SignUpAsync(string login, string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task SignOutAsync()
    {
        return Task.CompletedTask;
    }
}