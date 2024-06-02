namespace Ekid.Identity.Users;

public record UserSummary(Guid Id, string Name, string Email, bool IsActive, string Role)
{
    public static UserSummary FromUserAccount(UserAccount user)
    {
        return new UserSummary(
            user.Id.Id,
            $"{user.FirstName} {user.LastName}",
            user.Email,
            user.IsActive,
            user.Role.Value
        );
    }
}