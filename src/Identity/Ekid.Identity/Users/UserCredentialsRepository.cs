using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Users;

public class UserCredentialsRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserCredentialsRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }
    
    public async Task AddAsync(UserCredentials user, CancellationToken cancellationToken)
    {
        await _identityDbContext.UsersCredentials.AddAsync(user, cancellationToken);
    }
    
    public async Task<UserCredentials?> GetByIdAsync(UserId id, CancellationToken cancellationToken)
    {
        return await _identityDbContext.UsersCredentials.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<UserCredentials?> FindAsync(UserCredentials user, CancellationToken token)
    {
        return await _identityDbContext.UsersCredentials.AsNoTracking().SingleOrDefaultAsync(x =>
            x.Id == user.Id 
            || x.Email == user.Email 
            || x.Login == user.Login, token);
    }
}