using Ekid.Identity.Contracts.Tenants.Commands;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Tenants;

public class TenantCommandsHandler : 
    ICommandHandler<CreateTenant>, 
    ICommandHandler<ActivateTenant>
{
    private readonly TenantRepository _repository;

    public TenantCommandsHandler(TenantRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateTenant command, CancellationToken cancellationToken)
    {
        var tenantSummary = await _repository.GetByNameAsync(command.Name, cancellationToken);
        if (tenantSummary is not null)
            throw new Exception($"Tenant with name {command.Name} already exists.");

        var tenant = new Tenant(TenantId.New(), command.Name, command.Description, isActive: false);
        await _repository.AddAsync(tenant, cancellationToken);
    }

    public Task HandleAsync(ActivateTenant command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}