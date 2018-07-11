using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IContactService
    {
        /// <summary>
        /// Get Contacts
        /// </summary>
        /// <param name="email">Contact Email</param>
        /// <returns>IEnumerable of Contact Objects</returns>
        IEnumerable<Contact> GetContacts(string email);

        /// <summary>
        /// Create a Contact
        /// </summary>
        /// <param name="email">Contact Email</param>
        /// <param name="firstName">Contact First Name</param>
        /// <param name="lastName">Contact Last Name</param>
        /// <returns>Bool; record created</returns>
        bool CreateContact(string email, string firstName, string lastName);

        /// <summary>
        /// Update a Contact Record
        /// </summary>
        /// <param name="id">Contact Record Id</param>
        /// <param name="email">Contact Email</param>
        /// <param name="firstName">Contact First Name</param>
        /// <param name="lastName">Contact Last Name</param>
        /// <returns>Bool; record updated</returns>
        bool UpdateContact(int id, string email, string firstName, string lastName);

        /// <summary>
        /// Delete a Contact Record
        /// </summary>
        /// <param name="id">Contact Record Id</param>
        /// <returns>Bool; record deleted</returns>
        bool DeleteContact(int id);
    }
}