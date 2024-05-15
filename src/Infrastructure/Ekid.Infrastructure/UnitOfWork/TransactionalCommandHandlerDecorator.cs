using Ekid.Infrastructure.Attributes;
using Ekid.Infrastructure.Messaging;
using Ekid.Infrastructure.ModuleContext;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.UnitOfWork;

[ExcludeFromAutoRegistration]
public class TransactionalCommandHandlerDecorator<T>(ICommandHandler<T> handler, IServiceProvider serviceProvider)
    : ICommandHandler<T>
    where T : class, ICommand
{
    public async Task HandleAsync(T command)
    {
        var moduleName = ModuleName.Of(typeof(T));
        var unitOfWork = serviceProvider.GetKeyedService<IUnitOfWork>(moduleName);
        if (unitOfWork is null)
        {
            await handler.HandleAsync(command);
            return;
        }

        await unitOfWork.ExecuteAsync(() => handler.HandleAsync(command));
    }
}