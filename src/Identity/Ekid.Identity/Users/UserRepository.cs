namespace Ekid.Identity.Users;

public class UserRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task Add(User user)
    {
        await _identityDbContext.Users.AddAsync(user);
    }
    
    //TODO the rest
}