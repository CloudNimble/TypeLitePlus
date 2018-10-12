using System;

namespace TypeLitePlus.Tests.NetCore.TestModels
{
    public class Address {
	    public const int DefaultCountryId = 1;
	    public const string DefaultPostalCode = "";

        public Guid Id { get; set; }
        public Guid[] Ids { get; set; }
		public string Street { get; set; }
		public string Town { get; set; }
        
        // field
	    public string PostalCode;
		
        public ContactType AddressType { get; set; }
        public ConsoleKey Shortkey { get; set; }

        [TsProperty(IsOptional=true)]
        public int CountryID { get; set; }
	}
}
