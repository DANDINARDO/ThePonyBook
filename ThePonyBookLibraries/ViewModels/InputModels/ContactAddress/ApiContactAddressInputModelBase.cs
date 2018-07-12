using System.Data;

namespace ThePonyBookLibraries.ViewModels.InputModels.ContactAddress
{
    public abstract class ApiContactAddressInputModelBase
    {
        public int ContactId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public int CountryId { get; set; }
    }
}
