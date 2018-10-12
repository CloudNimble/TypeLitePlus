using Xunit;
using TypeLitePlus;
using System.Diagnostics;

namespace TypeLitePlus.Tests.NetCore.RegressionTests
{
    public class JsDocTests
    {
        [Fact]
        public void GenericClassWithTypeparam()
        {
            // Exception raised documenting generic class with typeparam.
            var ts = TypeScript.Definitions().WithJSDoc()
                .For<UserPreference>();
            string result;

            var ex = Record.Exception(() => result = ts.Generate(TsGeneratorOutput.Properties));
            Assert.Null(ex);
            Debug.Write(ts);
        }

        /// <summary>
        /// User Preference
        /// </summary>
        public class UserPreference
        {
            /// <summary>
            /// Preferences's document.
            /// </summary>
            public GenericClass1<string> Preferences { get; set; }
        }

        /// <summary>
        /// GenericClass with T1
        /// </summary>
        /// <typeparam name="T1">typeparam T1</typeparam>
        public class GenericClass1<T1>
        {
            /// <summary>
            /// T1 Property
            /// </summary>
            public T1 Property1 { get; set; }
        }
    }
}
