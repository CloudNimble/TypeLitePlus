using System.Collections.Generic;

namespace TypeLitePlus.Tests.NetCore.TestModels
{
    public class Person
    {
        public const int MaxAddresses = 3;
        public const string DefaultPhoneNumber = "[None]";

        public string Name { get; set; }
        public int YearOfBirth { get; set; }

        // field
        public string PhoneNumber;

        public Address PrimaryAddress { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
