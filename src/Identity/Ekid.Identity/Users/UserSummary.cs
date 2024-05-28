namespace Ekid.Identity.Users;

public record UserSummary(Guid Id, string Name, string Login, string Email, bool IsActive, string Role)
{
    public static UserSummary FromUser(User user)
    {
        return new UserSummary(
            user.Id,
            $"{user.FirstName} {user.LastName}",
            user.Login,
            user.Email,
            user.IsActive,
            user.Role.Value
        );
    }
}