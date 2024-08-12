using System.Net;
using Ekid.Web.ApiClient;
using MudBlazor;

namespace Ekid.Web.UI.Services;

public interface IApiResponseHandler
{
    Task<ApiResponse?> HandleAsync(Task<ApiResponse> request);
    Task<T?> HandleAsync<T>(Task<ApiResponse<T>> request);
}

public class ApiResponseHandler : IApiResponseHandler
{
    private readonly ISnackbar _snackbar;
    private readonly IAuthenticationService _authenticationService;

    public ApiResponseHandler(ISnackbar snackbar, IAuthenticationService authenticationService)
    {
        _snackbar = snackbar;
        _authenticationService = authenticationService;
    }

    public async Task<ApiResponse?> HandleAsync(Task<ApiResponse> request)
    {
        var response = await request;
        if (response.Succeeded)
        {
            return response;
        }

        await HandleErrorAsync(response);
        return default;
    }

    public async Task<T?> HandleAsync<T>(Task<ApiResponse<T>> request)
    {
        var response = await request;
        if (response.Succeeded)
        {
            return response.Value;
        }

        await HandleErrorAsync(response);
        return default;
    }
    
    private async Task HandleErrorAsync(ApiResponse response)
    {
        if (response.HttpResponse?.StatusCode == HttpStatusCode.Unauthorized)
        {
            _snackbar.Add("Your session has expired - please sign in again.", Severity.Error);
            await _authenticationService.LogOutAsync();
            return;
        }

        if (response.Errors?.Errors is not null)
        {
            foreach (var error in response.Errors.Errors)
            {
                _snackbar.Add(error.Message, Severity.Error);
            }
        }
    }
}