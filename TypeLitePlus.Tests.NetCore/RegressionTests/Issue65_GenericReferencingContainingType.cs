using System.Collections.Generic;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue65_GenericReferencingContainingType {
        [Fact]
        public void WhenClassReferencesItself_ClassIsGenerated() {
            var builder = new TsModelBuilder();
            builder.Add<GenericWithSelfReference>();

            var generator = new TsGenerator();
            var model = builder.Build();
            var result = generator.Generate(model);

            Assert.Contains("Children: TypeLitePlus.Tests.NetCore.RegressionTests.GenericWithSelfReference[]", result);
        }

    }

    public class GenericWithSelfReference {
        public List<GenericWithSelfReference> Children { get; set; }
    }
}
