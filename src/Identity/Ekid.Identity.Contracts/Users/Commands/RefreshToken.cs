namespace Ekid.Identity.Contracts.Users.Commands;

public record RefreshToken(string SecureStamp) : ICommand
{
    public UserAccessToken Token { get; set; }
}