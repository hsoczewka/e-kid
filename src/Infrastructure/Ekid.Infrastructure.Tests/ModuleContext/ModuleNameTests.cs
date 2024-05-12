using Ekid.Infrastructure.ModuleContext;
using Ekid.ModuleA.Commands;
using Ekid.ModuleB.Commands;
using FluentAssertions;

namespace Ekid.Infrastructure.Tests.ModuleContext
{
    public class ModuleNameTests
    {
        [Theory]
        [InlineData("modulea", typeof(CommandA))]
        [InlineData("moduleb", typeof(CommandB))]
        public void CanCreateFromNamespaceOfGivenType(string expectedName, Type givenType)
        {
            var moduleName = ModuleName.Of(givenType);
            moduleName.Value.Should().Be(expectedName);
        }
    
    }
}

namespace Ekid.ModuleA.Commands
{
    internal record CommandA();
}

namespace Ekid.ModuleB.Commands
{
    internal record CommandB();
}

