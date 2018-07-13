using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IContactPhoneService
    {
        /// <summary>
        /// Get Contact Phones
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>IEnumerable of ContactPhone Objects</returns>
        IEnumerable<ContactPhone> GetContactPhones(int contactId);

        /// <summary>
        /// Create a Contact Phone Record
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <param name="areaCode">Area Code</param>
        /// <param name="phone">Phone</param>
        /// <param name="phoneTypeId">Phone Type Id</param>
        /// <returns>Bool; contact phone record created</returns>
        bool CreateContactPhone(int contactId, int? areaCode, int? phone, int? phoneTypeId);

        /// <summary>
        /// Update a Contact Phone Record
        /// </summary>
        /// <param name="id">Contact Phone Id</param>
        /// <param name="areaCode">Area Code</param>
        /// <param name="phone">Phone</param>
        /// <param name="phoneTypeId">Phone Type Id</param>
        /// <returns>Bool; contact phone record updated</returns>
        bool UpdateContactPhone(int id, int? areaCode, int? phone, int? phoneTypeId);

        /// <summary>
        /// Delete a Contact Phone Record
        /// </summary>
        /// <param name="id">Contact Phone Id</param>
        /// <returns>Bool; contact phone record deleted</returns>
        bool DeleteContactPhone(int id);
    }
}