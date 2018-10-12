using System;
using System.Collections.Generic;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue32_DuplicateInterfacesForClosedGenericPropertyTypes
    {
        [Fact]
        public void WhenClosedGenericTypeAppearsAsPropertyTypeMultipleTimes_OnlyOneInterfaceGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<GenericPropertiesBug>();

            var generator = new TsGenerator();
            var model = builder.Build();

            var result = generator.Generate(model);

            Assert.True(result.IndexOf("interface KeyValuePair") > -1, "KeyValuePair interface missing");
            Assert.True(result.IndexOf("interface KeyValuePair") == result.LastIndexOf("interface KeyValuePair"), "KeyValuePair interface generated too many times");

            Assert.Contains("Test1: System.Collections.Generic.KeyValuePair", result);
            Assert.Contains("Test2: System.Collections.Generic.KeyValuePair", result);
        }

        [TsClass]
        public class GenericPropertiesBug 
        { 
            public KeyValuePair<string, string> Test1 { get; set; } 
            public KeyValuePair<string, int> Test2 { get; set; } 
        }
    }
}
