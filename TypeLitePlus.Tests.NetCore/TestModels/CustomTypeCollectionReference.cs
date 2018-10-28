using System.Collections.Generic;

namespace TypeLitePlus.Tests.NetCore.TestModels
{
    public class CustomTypeCollectionReference
    {
        public Product[] Products { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}
