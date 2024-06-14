using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Users;

public class UserRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task AddAsync(UserAccount user, CancellationToken cancellationToken)
    {
        await _identityDbContext.UsersAccounts.AddAsync(user, cancellationToken);
    }

    public async Task<UserSummary?> GetByIdAsync(UserId id, CancellationToken cancellationToken)
    {
        var user = await _identityDbContext.UsersAccounts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return user is not null ? UserSummary.FromUserAccount(user) : default;
    }

    public async Task<UserSummary?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        var user = await _identityDbContext.UsersAccounts.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
        return user is not null ? UserSummary.FromUserAccount(user) : default;
    }

    //TODO the rest
}