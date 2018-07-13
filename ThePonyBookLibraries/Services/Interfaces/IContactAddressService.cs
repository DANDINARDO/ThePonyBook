using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IContactAddressService
    {
        /// <summary>
        /// Contact Addresses
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>IEnumerable of Contact Address Objects</returns>
        IEnumerable<ContactAddress> GetContactAddresses(int contactId);

        /// <summary>
        /// Create Contact Address
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <param name="address1">Address 1</param>
        /// <param name="address2">Address 2</param>
        /// <param name="city">City</param>
        /// <param name="region">Region/State</param>
        /// <param name="postalCode">Postal Code</param>
        /// <param name="countryId">Country</param>
        /// <returns>Bool; record created</returns>
        bool CreateContactAddress(int contactId, string address1, string address2, string city, string region, string postalCode, int countryId);

        /// <summary>
        /// Update Contact Address
        /// </summary>
        /// <param name="id">Contact Address Id</param>
        /// <param name="address1">Address 1</param>
        /// <param name="address2">Address 2</param>
        /// <param name="city">City</param>
        /// <param name="region">Region/State</param>
        /// <param name="postalCode">Postal Code</param>
        /// <param name="countryId">Country</param>
        /// <returns>Bool; record created</returns>
        bool UpdateContactAddress(int id, string address1, string address2, string city, string region, string postalCode, int countryId);

        /// <summary>
        /// Delete Contact Address
        /// </summary>
        /// <param name="id">Contact Address Id</param>
        /// <returns>Bool; record deleted</returns>
        bool DeleteContactAddress(int id);
    }
}