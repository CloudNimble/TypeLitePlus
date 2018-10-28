using System;
using TypeLitePlus.Tests.NetCore.TestModels;
using TypeLitePlus.TsModels;
using Xunit;

namespace TypeLitePlus.Tests.NetCore.TsModels
{
    public class TsEnumTests
    {

        [Fact]
        public void WhenInitializedWithNonEnumType_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new TsEnum(typeof(Address)));
        }

        [Fact]
        public void WhenInitialized_NameIsSet()
        {
            var target = new TsEnum(typeof(ContactType));

            Assert.Equal("ContactType", target.Name);
        }
    }
}
