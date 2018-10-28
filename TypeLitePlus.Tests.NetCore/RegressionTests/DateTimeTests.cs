using System;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class DateTimeTests
    {
        [Fact]
        public void WhenDateTimePropertyIsInModel_DateWithUppercaseDIsGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<ModelWithDateTime>();

            var generator = new TsGenerator();
            var model = builder.Build();
            var result = generator.Generate(model);

            Assert.Contains("Property: Date", result);
        }
    }

    public class ModelWithDateTime
    {
        public DateTime Property { get; set; }
    }
}
