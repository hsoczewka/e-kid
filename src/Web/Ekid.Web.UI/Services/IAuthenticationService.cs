using Ekid.Web.Auth;
using Ekid.Web.Models.Identity;
using Ekid.Web.Storage;
using Ekid.Web.Users;
using Ekid.Web.Users.Contracts;
using Microsoft.AspNetCore.Components;

namespace Ekid.Web.UI.Services;

public interface IAuthenticationService
{
    //User? User { get; }
    Task InitializeAsync();
    Task<bool?> LoginAsync(string email, string password);
    Task LogOutAsync();
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserAccountClient _accountClient;
    private readonly ILocalStorage _localStorage;
    private readonly NavigationManager _navigationManager;
    private readonly JwtAuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(
        IUserAccountClient accountClient, 
        ILocalStorage localStorage, 
        NavigationManager navigationManager, 
        JwtAuthenticationStateProvider authenticationStateProvider)
    {
        _accountClient = accountClient;
        _localStorage = localStorage;
        _navigationManager = navigationManager;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public User? User { get; private set; }
    
    public async Task InitializeAsync()
    {
        var response = await _accountClient.RefreshTokenAsync();
        if (!string.IsNullOrWhiteSpace(response.Value?.AccessToken))
        {
            _authenticationStateProvider.Login(response.Value.AccessToken);
        }
        //User = await _localStorage.GetItemAsync<User>("user");
    }

    public async Task<bool?> LoginAsync(string email, string password)
    {
        var response = await _accountClient.LoginAsync(new LogIn(email, password));

        if (response.HttpResponse is null)
            return null;
        if (!response.Succeeded)
            return false;
        if (string.IsNullOrWhiteSpace(response.Value?.AccessToken))
            return false;

        //User = new User(Email: email, Role: "", AccessToken: response.Value.AccessToken, Expires: 30);
        //await _localStorage.SetItemAsync("user", User);
        _authenticationStateProvider.Login(response.Value.AccessToken);
        return true;
    }

    public async Task LogOutAsync()
    {
        //User = null;
        //await _localStorage.RemoveItemAsync("user");
        _authenticationStateProvider.Logout();
        _navigationManager.NavigateTo("identity/user/login");
    }
}