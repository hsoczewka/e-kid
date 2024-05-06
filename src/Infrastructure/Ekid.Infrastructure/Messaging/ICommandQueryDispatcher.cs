namespace Ekid.Infrastructure.Messaging;

public interface ICommandQueryDispatcher
{
    Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    Task<TResult> SendAsync<TResult>(IQuery<TResult> query);
}