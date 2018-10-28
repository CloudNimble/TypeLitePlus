using System.Linq;
using TypeLitePlus.Tests.NetCore.TestModels;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue79_ModuleNameFormatterIsnNotUsed
    {
        [Fact]
        public void WhenScriptGeneratorGenerateIsCalledModuleNameFormatterIsUsed()
        {

            var ts = TypeScript.Definitions();
            ts.WithModuleNameFormatter(m => "XXX");
            ts.ModelBuilder.Add<Product>();

            var model = ts.ModelBuilder.Build();
            var myType = model.Classes.First();
            var name = ts.ScriptGenerator.GetFullyQualifiedTypeName(myType);

            Assert.Equal("XXX.Product", name);
        }
    }
}
