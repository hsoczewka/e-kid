namespace Ekid.Web.Models.Identity;

public record User(string Email, string Role, string AccessToken, long Expires);