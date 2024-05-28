using Ekid.Infrastructure.UnitOfWork;

namespace Ekid.Identity;

internal class IdentityUnitOfWork(IdentityDbContext dbContext) : UnitOfWork<IdentityDbContext>(dbContext);