using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue15_ConvertSystemType {
		[Fact]
		public void WhenClassContainsPropertyOfSystemType_InvalidCastExceptionIsntThrown() {
			var builder = new TsModelBuilder();
			builder.Add<Issue15Example>();

			var generator = new TsGenerator();
			var model = builder.Build();

            var ex = Record.Exception(() => generator.Generate(model));
            Assert.Null(ex);
		}
	}

	public class Issue15Example {
		public System.Type Type { get; set; }
	}
}
