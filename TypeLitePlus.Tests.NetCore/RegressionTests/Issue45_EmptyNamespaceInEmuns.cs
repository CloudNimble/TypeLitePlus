using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue45_EmptyNamespaceInEmuns
    {
        [Fact]
        public void WhenModuleDoesntContainsAnyEnums_ItIsntGeneratedWithEnumsOption()
        {
            var builder = new TsModelBuilder();
            builder.Add<MyTestClass>();

            var generator = new TsGenerator();
            var model = builder.Build();
            var result = generator.Generate(model, TsGeneratorOutput.Enums);

            Assert.DoesNotContain("MyTestModule", result);
        }

        [TsClass(Module = "MyTestModule")]
        public class MyTestClass
        {
            public int ID { get; set; }
            public MyTestEnum Enum { get; set; }
        }

        [TsEnum(Module = "EnumsModule")]
        public enum MyTestEnum
        {
            One,
            Two,
            Three
        }
    }
}
