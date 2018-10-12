using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class Issue88_TypeformatterAppliedToOpenGenericsParameters {

        [Fact(Skip="Not fixed")]
        public void WhenTypeFormaterIsUsed_ItIsntAppliedToOpenGenericsParameters() {
            var ts = TypeScript.Definitions()
                .For<UserPreference>()
                .WithTypeFormatter(((type, F) => "I" + ((TypeLitePlus.TsModels.TsClass)type).Name))
                .Generate();

            Debug.Write(ts);

            Assert.Contains("Key: TKey", ts);
            Assert.Contains("Value: TValue", ts);
        }


        public class UserPreference {
            public Dictionary<string, string> Preferences { get; set; }
        }
    }
}
