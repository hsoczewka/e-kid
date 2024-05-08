namespace Ekid.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}