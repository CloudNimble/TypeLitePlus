#if !NETSTANDARD2_0 && !NETCOREAPP2_1 && !NETCOREAPP2_2

using System.Data.Spatial;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class DbGeometryIgnoreTests {
		[Fact]
		public void WhenPropertyWithDbGeometryTypeIsAnnotedWithTsIgnoreAttribute_GeneratorDoesntCrash() {
			var builder = new TsModelBuilder();
			builder.Add<DbGeometryTestClass>();

			var generator = new TsGenerator();
			var model = builder.Build();

			Assert.DoesNotThrow(() => generator.Generate(model));
		}
	}

	public class DbGeometryTestClass {
		public int ID { get; set; }

		[TsIgnore]
		public DbGeometry Position { get; set; }
	}
}
#endif