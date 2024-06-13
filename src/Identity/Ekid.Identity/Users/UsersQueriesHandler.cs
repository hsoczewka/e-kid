using Ekid.Identity.Contracts.Users.Queries;
using Ekid.Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Users;

public class UsersQueriesHandler : IQueryHandler<GetUsers, UsersResponse>
{
    private readonly IdentityDbContext _identityDbContext;
    private readonly IQueryable<UserAccount> _userAccounts;

    public UsersQueriesHandler(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
        _userAccounts = identityDbContext.UsersAccounts.AsQueryable();
    }

    public async Task<UsersResponse> HandleAsync(GetUsers query, CancellationToken token)
    {
        var accounts = await _userAccounts.ToListAsync(token);

        return new UsersResponse(accounts.Select(
            account =>
                new UserDetails(UserId: account.Id.Id,
                    Email: account.Email.Value,
                    FirstName: account.FirstName,
                    LastName: account.LastName,
                    Role: account.Role.Value,
                    IsActive: account.IsActive,
                    CreatedAt: account.CreatedAt)).ToList());
    }
}