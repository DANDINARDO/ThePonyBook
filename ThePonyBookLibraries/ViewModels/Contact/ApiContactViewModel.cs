using System.Collections.Generic;
using ThePonyBookLibraries.ViewModels.ContactAddress;
using ThePonyBookLibraries.ViewModels.ContactPhone;

namespace ThePonyBookLibraries.ViewModels.Contact
{
    public class ApiContactViewModel
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Email { get; set;  }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<ApiContactAddressViewModel> ContactAddresses { get; set; }

        public IEnumerable<ApiContactPhoneViewModel> ContactPhones { get; set; }

    }
}
