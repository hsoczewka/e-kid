using Ekid.Infrastructure.Security;

namespace Ekid.Resources.Contracts.Security;

public class Permissions : IPermissionRegistry
{
    public static Permission ManageEmployee => new Permission("ManageEmployee", Guid.Parse("37d4c858-04c4-4f5b-908a-a6be34a1386a"));
    public static Permission ViewEmployee => new Permission("ViewEmployee", Guid.Parse("b458dfca-487f-4f95-911b-33a35309658d"));
    
    public static Permission ManageActivity => new Permission("ManageActivity", Guid.Parse("22a0766a-b49c-45a2-8418-9f93e25a6440"));
    public static Permission ViewActivity => new Permission("ViewActivity", Guid.Parse("fd6a7358-007e-4bc4-90db-da512ceb0057"));

    public void ConfigurePermissions(PermissionContainer container) 
        => container.Register(new []{ManageEmployee, ViewEmployee, ManageActivity, ViewActivity});
}