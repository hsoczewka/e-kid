using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Contracts.Users.Queries;

public class GetUsers : IQuery<UsersResponse>
{
    
}

public record UsersResponse(IReadOnlyCollection<UserDetails> UsersDetails);

public record UserDetails(Guid UserId, string Email, string FirstName, string LastName, string Role, bool IsActive, DateTime CreatedAt);