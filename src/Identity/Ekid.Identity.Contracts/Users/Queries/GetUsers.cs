using Ekid.Infrastructure.ExecutionPolicy;

namespace Ekid.Identity.Contracts.Users.Queries;

[RequireAdmin]
public class GetUsers : IQuery<UsersResponse>
{
    
}

public record UsersResponse(IReadOnlyCollection<UserDetails> UsersDetails);

public record UserDetails(Guid UserId, string Email, string FirstName, string LastName, string Role, bool IsActive, DateTime CreatedAt);