using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Users;

public class UserRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _identityDbContext.Users.AddAsync(user, cancellationToken);
    }

    public async Task<UserSummary?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _identityDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return user is not null ? UserSummary.FromUser(user) : default;
    }

    public async Task<UserSummary?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _identityDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
        return user is not null ? UserSummary.FromUser(user) : default;
    }

    //TODO the rest
}