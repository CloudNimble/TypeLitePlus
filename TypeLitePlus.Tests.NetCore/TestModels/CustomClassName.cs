namespace TypeLitePlus.Tests.NetCore.TestModels
{
    [TsClass(Name = "MyClass", Module = "MyModule")]
	public class CustomClassName {
		[TsProperty(Name = "MyProperty")]
		public int CustomPorperty { get; set; }
	}
}
