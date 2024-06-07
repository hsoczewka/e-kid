using Ekid.Infrastructure.ExecutionPolicy;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Contracts.Tenants.Commands;

[RequireAdmin]
public record CreateTenant(string Name, string Description) : ICommand;