namespace Ekid.Infrastructure.ModuleContext;

public class ModuleName
{
    private const string Prefix = "Ekid.";
    public string Value { get; }
    
    private ModuleName(string value)
    {
        Value = value;
    }
    
    public static ModuleName Of(Type type)
    {
        if (type?.Namespace is null)
        {
            return new ModuleName(string.Empty);
        }

        return type.Namespace.StartsWith(Prefix)
            ? new ModuleName(type.Namespace.Split(".")[1].ToLowerInvariant())
            : new ModuleName(string.Empty);
    }
}