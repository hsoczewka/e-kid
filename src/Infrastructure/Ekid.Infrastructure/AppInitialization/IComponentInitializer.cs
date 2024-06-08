namespace Ekid.Infrastructure.AppInitialization;

public interface IComponentInitializer
{
    Task InitializeAsync(CancellationToken token);
}