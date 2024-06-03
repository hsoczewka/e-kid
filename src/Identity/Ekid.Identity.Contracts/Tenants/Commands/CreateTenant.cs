using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Contracts.Tenants.Commands;

public record CreateTenant(string Name, string Description) : ICommand;