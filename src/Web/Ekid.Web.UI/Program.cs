using Ekid.Web;
using Ekid.Web.ApiClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ekid.Web.UI;
using Ekid.Web.UI.Services;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddApiClientComponents<CookieRequestHandler>();
builder.Services.AddWebCore();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IApiResponseHandler, ApiResponseHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddMudServices();
builder.Services.AddMudBlazorSnackbar(config =>
{
    config.PositionClass = Defaults.Classes.Position.TopRight;
    config.PreventDuplicates = false;
    config.NewestOnTop = false;
    config.ShowCloseIcon = true;
    config.VisibleStateDuration = 5000;
    config.HideTransitionDuration = 200;
    config.ShowTransitionDuration = 200;
});

var host = builder.Build();
var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.InitializeAsync(); //Refresh token
await host.RunAsync();
//await builder.Build().RunAsync();

//https://www.reddit.com/r/csharp/comments/u6n8nz/the_bullshitless_aspnet_blazor_wasm_jwt/