namespace Ekid.Web.Models.Identity;

public record User(string Id, string Email, string Role, string AccessToken, string RefreshToken, long Expires);