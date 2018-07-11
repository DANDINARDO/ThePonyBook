using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePonyBookLibraries.ViewModels.Country;

namespace ThePonyBookLibraries.ViewModels.ContactAddress
{
    public class ApiContactAddressViewModel
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public ApiCountryViewModel Country { get; set; }
    }
}
