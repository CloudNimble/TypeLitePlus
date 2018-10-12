using Xunit;

namespace TypeLitePlus.Tests.NetCore
{
    public class TypeConvertorCollectionTests {
		[Fact]
		public void WhenConvertTypeAndNoConverterRegistered_NullIsReturned() {
			var target = new TypeConvertorCollection();

			var result = target.ConvertType(typeof(string));

			Assert.Null(result);
		}

		[Fact]
		public void WhenConvertType_ConvertedValueIsReturned() {
			var target = new TypeConvertorCollection();
			target.RegisterTypeConverter<string>(type => "KnockoutObservable<string>");

			var result = target.ConvertType(typeof(string));

			Assert.Equal("KnockoutObservable<string>", result);
		}
	}
}
