namespace Ekid.Identity.Contracts.Users.Commands;

public record LogIn(string Email, string Password) : ICommand
{
    public UserAccessToken Token { get; set; }
}

public record UserAccessToken(string AccessToken);