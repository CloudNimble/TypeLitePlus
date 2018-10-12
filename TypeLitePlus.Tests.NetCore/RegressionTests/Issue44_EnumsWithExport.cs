using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue44_EnumsWithExport {
        [Fact]
        public void WhenEnumIsGenerated_ItHasExportKeyword() {
            var builder = new TsModelBuilder();
            builder.Add<MyTestClass>();

            var generator = new TsGenerator();
            var model = builder.Build();
            var result = generator.Generate(model, TsGeneratorOutput.Enums);

            Assert.Contains("export", result);
        }

        public class MyTestClass {
            public int ID { get; set; }
            public MyTestEnum Enum { get; set; }
        }

        public enum MyTestEnum {
            One,
            Two,
            Three
        }
    }
}
