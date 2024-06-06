namespace Ekid.Infrastructure.ExecutionPolicy;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class RequireEmployeeAttribute : Attribute { }