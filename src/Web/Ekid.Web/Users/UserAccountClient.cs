using Ekid.Web.ApiClient;
using Ekid.Web.Users.Contracts;

namespace Ekid.Web.Users;

public interface IUserAccountClient
{
    Task<ApiResponse> SignUpAsync(SignUp request);
    Task<ApiResponse<AuthResponse>> LoginAsync(LogIn request);
    Task<ApiResponse<AuthResponse>> RefreshTokenAsync();
}

public class UserAccountClient : IUserAccountClient
{
    private readonly CustomHttpClient _client;

    public UserAccountClient(CustomHttpClient client)
    {
        _client = client;
    }

    public Task<ApiResponse> SignUpAsync(SignUp request)
        => _client.PostAsync("identity/user/sign-up", request);
    

    public Task<ApiResponse<AuthResponse>> LoginAsync(LogIn request)
        => _client.PostAsync<AuthResponse>("identity/user/login", request);
    
    public Task<ApiResponse<AuthResponse>> RefreshTokenAsync()
        => _client.PostAsync<AuthResponse>("identity/user/refresh-token");
}