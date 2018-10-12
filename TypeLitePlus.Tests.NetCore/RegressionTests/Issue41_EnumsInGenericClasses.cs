using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue41_EnumsInGenericClasses {
        [Fact]
        public void DoesNotThrowNullReferenceException_WhenEnumPropertyInGenericClass() {

            var ex = Record.Exception(() =>
            {
                var builder = new TsModelBuilder();
                builder.Add<Bob<object>>();

                var generator = new TsGenerator();
                var model = builder.Build();
                var result = generator.Generate(model);
            });
            Assert.Null(ex);
        }

        [TsClass]
        public class Bob<T> {
            public MyTestEnum MyEnum { get; set; }
            public string TestString { get; set; }
            public string MyProperty { get; set; }
        }

        [TsEnum]
        public enum MyTestEnum {
            One,
            Two,
            Three
        }
    }
}
