using System.Diagnostics.CodeAnalysis;
using Ekid.Infrastructure.Security;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.Tests.Security;

public class PermissionRegistryTests
{
    [Fact]
    public void CanRegisterAllPermissionsFromScannedAssemblies()
    {
        //given
        var serviceCollection = new ServiceCollection();
        var permissionContainer = new PermissionContainer();
        serviceCollection.AddSingleton(permissionContainer);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        //when
        serviceProvider.RegisterAllPermissions();

        //then
        permissionContainer.Permissions.Should().HaveCount(2);
        permissionContainer.Permissions.Should()
            .ContainSingle(x => x.Id == Guid.Parse("317d53aa-61d3-4981-87d4-535cce0889da"));
        permissionContainer.Permissions.Should()
            .ContainSingle(x => x.Id == Guid.Parse("0cd60fb3-9342-4780-99a2-aedf4d6f8b31"));
    }
    
    [ExcludeFromCodeCoverage]
    internal class TestPermission : IPermissionRegistry
    {
        public static Permission Permission1 => new Permission(nameof(Permission1), Guid.Parse("317d53aa-61d3-4981-87d4-535cce0889da"));
        public static Permission Permission2 => new Permission(nameof(Permission2), Guid.Parse("0cd60fb3-9342-4780-99a2-aedf4d6f8b31"));
        public void ConfigurePermissions(PermissionContainer container)
        {
            container.Register(new[] { Permission1, Permission2 });
        }
    }
}