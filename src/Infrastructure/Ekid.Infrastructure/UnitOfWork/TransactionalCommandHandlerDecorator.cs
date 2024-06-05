using Ekid.Infrastructure.Attributes;
using Ekid.Infrastructure.Messaging;
using Ekid.Infrastructure.ModuleContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ekid.Infrastructure.UnitOfWork;

[ExcludeFromAutoRegistration]
public class TransactionalCommandHandlerDecorator<T>
    : ICommandHandler<T>
    where T : class, ICommand
{
    private readonly ICommandHandler<T> _handler;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<TransactionalCommandHandlerDecorator<T>> _logger;

    public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler, IServiceProvider serviceProvider, ILogger<TransactionalCommandHandlerDecorator<T>> logger)
    {
        _handler = handler;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task HandleAsync(T command, CancellationToken cancellationToken)
    {
        var moduleName = ModuleName.Of(typeof(T));
        var unitOfWork = _serviceProvider.GetKeyedService<IUnitOfWork>(moduleName.Value);
        if (unitOfWork is null)
        {
            _logger.LogInformation($"Unit of work not found for key: {moduleName.Value}");
            await _handler.HandleAsync(command, cancellationToken);
            return;
        }

        _logger.LogInformation($"Handling command {command.GetType().Name} using {unitOfWork.GetType().Name} unit of work.");
        await unitOfWork.ExecuteAsync(() => _handler.HandleAsync(command, cancellationToken));
    }
}