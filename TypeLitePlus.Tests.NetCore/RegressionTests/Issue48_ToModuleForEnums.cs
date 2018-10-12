using System;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue48_ToModuleForEnums
    {
        [Fact]
        public void WhenModuleContainsStandAloneEnumWithToModule_EnumIsGeneratedInTheSpecifiedModule()
        {
            var ts = TypeScript.Definitions()
                .For<MyTestEnum>().ToModule("Foo")
                .Generate();
            Console.WriteLine(ts);
            Assert.Contains("namespace Foo", ts);
            Assert.Contains("enum MyTestEnum", ts);
        }

        enum MyTestEnum
        {
            One,
            Two,
            Three
        }
    }
}