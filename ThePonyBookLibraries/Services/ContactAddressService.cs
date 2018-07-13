using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly IDbContext _dbContext;

        #region Constructors 

        public ContactAddressService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<ContactAddress> GetContactAddresses(int contactId)
        {
            return RetrieveContactAddresses(contactId);
        }

        public bool CreateContactAddress(int contactId, string address1, string address2, string city, string region, string postalCode, int countryId)
        {
            return ProcessCreateContactAddress(contactId, address1, address2, city, region, postalCode, countryId);
        }

        public bool UpdateContactAddress(int id, string address1, string address2, string city, string region, string postalCode, int countryId)
        {
            return ProcessUpdateContactAddress(id, address1, address2, city, region, postalCode, countryId);
        }

        public bool DeleteContactAddress(int id)
        {
            return ProcessDeleteContactAddress(id);
        }

        #endregion

        #region Private Methods

        private IEnumerable<ContactAddress> RetrieveContactAddresses(int contactId)
        {
            try
            {
                var contactAddresses = _dbContext.Contacts.FirstOrDefault(x => x.Id == contactId)?.ContactAddresses.ToList();
                return contactAddresses;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessCreateContactAddress(int contactId, string address1, string address2, string city, string region, string postalCode, int countryId )
        {
            try
            {
                var contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == contactId);
                if (contact == null)
                    return false;

                var country = _dbContext.Countries.FirstOrDefault(x => x.Id == countryId);

                var contactAddress = new ContactAddress()
                {
                    ContactId = contact.Id,
                    Address1 = address1,
                    Address2 = address2,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country         
                };

                contact.ContactAddresses.Add(contactAddress);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessUpdateContactAddress(int id, string address1, string address2, string city, string region, string postalCode, int countryId)
        {
            try
            {
                var contactAddress = _dbContext.ContactAddresses.FirstOrDefault(x => x.Id == id);
                if (contactAddress == null)
                    return false;

                var country = _dbContext.Countries.FirstOrDefault(x => x.Id == countryId);

                contactAddress.Address1 = address1;
                contactAddress.Address2 = address2;
                contactAddress.City = city;
                contactAddress.Region = region;
                contactAddress.PostalCode = postalCode;
                contactAddress.Country = country;

                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessDeleteContactAddress(int id)
        {
            try
            { 
            var contactAddress = _dbContext.ContactAddresses.FirstOrDefault(x => x.Id == id);
            if (contactAddress == null)
                return false;

            _dbContext.ContactAddresses.Remove(contactAddress);
            _dbContext.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        #endregion
    }
}
