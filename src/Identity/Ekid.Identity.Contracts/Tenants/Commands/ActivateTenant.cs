using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Contracts.Tenants.Commands;

public record ActivateTenant(Guid Id) : ICommand;