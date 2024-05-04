using Ekid.Infrastructure.Identity.Authorization;

namespace Ekid.ResourcesManagement.Contracts.Security;

public class Permissions
{
    public static Permission AddEmployee => new Permission("AddEmployee", Guid.Parse("37d4c858-04c4-4f5b-908a-a6be34a1386a"));
    public static Permission RemoveEmployee => new Permission("RemoveEmployee", Guid.Parse("b458dfca-487f-4f95-911b-33a35309658d"));
    
    public static Permission AddActivity => new Permission("AddActivity", Guid.Parse("22a0766a-b49c-45a2-8418-9f93e25a6440"));
    public static Permission RemoveActivity => new Permission("RemoveActivity", Guid.Parse("fd6a7358-007e-4bc4-90db-da512ceb0057"));
}