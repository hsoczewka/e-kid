using Ekid.Infrastructure.AppInitialization;
using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Users;

public class UserAccountInitializer : IComponentInitializer
{
    private readonly IdentityDbContext _identityDbContext;

    public UserAccountInitializer(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task InitializeAsync(CancellationToken token)
    {
        if (await _identityDbContext.UsersAccounts.AnyAsync(token))
        {
            return;
        }

        await AddDefaultAsync();
        await _identityDbContext.SaveChangesAsync(token);
    }
    
    private async Task AddDefaultAsync()
    {
        await _identityDbContext.UsersAccounts.AddAsync(
            new UserAccount(id: UserId.New(), 
                email: "email@superadmin.com", 
                firstName: "Super", 
                lastName: "Admin", 
                role: UserRole.Administrator,
                new HashSet<Guid>(),
                new HashSet<Guid>(),
                isActive: true,
                createdAt: DateTime.UtcNow));
    }
}