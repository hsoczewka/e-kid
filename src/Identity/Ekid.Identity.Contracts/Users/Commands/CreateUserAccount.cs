using Ekid.Infrastructure.ExecutionPolicy;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Contracts.Users.Commands;

[RequireAdmin]
public record CreateUserAccount(string Email, string FirstName, string LastName, string Role, ISet<Guid>? Tenants, ISet<Guid>? Permissions) : ICommand;