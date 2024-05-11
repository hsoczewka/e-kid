using Ekid.Infrastructure.Attributes;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Infrastructure.UnitOfWork;

[ExcludeFromAutoRegistration]
public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T> where T : class, ICommand
{
    private readonly ICommandHandler<T> _handler;
    private readonly IServiceProvider _serviceProvider;

    public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler, IServiceProvider serviceProvider)
    {
        _handler = handler;
        _serviceProvider = serviceProvider;
    }

    public Task HandleAsync(T command)
    {
        throw new NotImplementedException();
    }
}