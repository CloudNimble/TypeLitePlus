using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue52_EnumsWithoutClass {

        [Fact]
        public void WhenAssemblyContainsEnumWithoutClass_EnumIsGeneratedInTheOutput() {
            var builder = new TsModelBuilder();
            builder.Add(typeof(TypeLitePlus.Tests.AssemblyWithEnum.TestEnum).Assembly);

            var generator = new TsGenerator();
            var model = builder.Build();
            var result = generator.Generate(model, TsGeneratorOutput.Enums);

            Assert.Contains("TestEnum", result);
        }

        enum MyTestEnum {
            One,
            Two,
            Three
        }
    }
}
