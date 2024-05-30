namespace Ekid.Identity.Users;

public record UserId(Guid Id)
{
    public static UserId New() => new UserId(Guid.NewGuid());
}