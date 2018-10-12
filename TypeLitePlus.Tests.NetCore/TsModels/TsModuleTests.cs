
using Xunit;

using TypeLitePlus.TsModels;

namespace TypeLitePlus.Tests.NetCore.TsModels
{
    public class TsModuleTests {

        [Fact]
        public void WhenInitialized_ClassesCollectionIsEmpty() {
            var target = new TsModule("Tests");

            Assert.NotNull(target.Classes);
            Assert.Empty(target.Classes);
        }

        [Fact]
        public void WhenInitialized_NameIsSet() {
            var target = new TsModule("Tests");

            Assert.Equal("Tests", target.Name);
        }
    }
}
