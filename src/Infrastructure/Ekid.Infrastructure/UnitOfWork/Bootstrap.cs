using Ekid.Infrastructure.Messaging;
using Ekid.Infrastructure.ModuleContext;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.UnitOfWork;

public static class Bootstrap
{
    public static void AddTransactionalHandlers(this IServiceCollection services)
        => services.TryDecorate(typeof(ICommandHandler<>), typeof(TransactionalCommandHandlerDecorator<>));
    
    public static void AddUnitOfWork<TUnitOfWork>(this IServiceCollection services)
        where TUnitOfWork : class, IUnitOfWork
        => services.AddKeyedScoped<IUnitOfWork, TUnitOfWork>(ModuleName.Of(typeof(TUnitOfWork)));
    
}