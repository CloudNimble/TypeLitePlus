using TypeLitePlus.Tests.NetCore.TestModels;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue14_IgnoreAttributeIsNotWorking {
		[Fact]
		public void WhenPropertyHastsIgnoreAttribute_TypeOfIgnoredPropertyIsExcludedFromModel() {
			var builder = new TsModelBuilder();
			builder.Add<Issue14Example>();

			var generator = new TsGenerator();
			var model = builder.Build();
			var script = generator.Generate(model);

			Assert.DoesNotContain("Person", script);
		}
	}

	public class Issue14Example {
		public string Name { get; set; }

		[TsIgnore]
		public Person Contact { get; set; }
	}
}
