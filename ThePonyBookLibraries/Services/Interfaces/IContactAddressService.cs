using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IContactAddressService
    {
        IEnumerable<ContactAddress> GetContactAddresses(string email);
        bool CreateContactAddress(int contactId, string address1, string address2, string city, string region, string postalCode, int countryId);
        bool UpdateContactAddress(int id, string address1, string address2, string city, string region, string postalCode, int countryId);
        bool DeleteContactAddress(int id);
    }
}