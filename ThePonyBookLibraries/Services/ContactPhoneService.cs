using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class ContactPhoneService : IContactPhoneService
    {
        private readonly IDbContext _dbContext;

        #region Constructors

        public ContactPhoneService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<ContactPhone> GetContactPhones(int contactId)
        {
            return RetrieveContactPhones(contactId);
        }

        public bool CreateContactPhone(int contactId, int? areaCode, int? phone, int? phoneTypeId)
        {
            return ProcessCreateContactPhone(contactId, areaCode, phone, phoneTypeId);
        }

        public bool UpdateContactPhone(int id, int? areaCode, int? phone, int? phoneTypeId)
        {
            return ProcessUpdateContactPhone(id, areaCode, phone, phoneTypeId);
        }

        public bool DeleteContactPhone(int id)
        {
            return ProcessDeleteContactPhone(id);
        }

        #endregion

        #region Private Methods

        private IEnumerable<ContactPhone> RetrieveContactPhones(int contactId)
        {
            try
            {
                var contactPhones = _dbContext.Contacts.FirstOrDefault(x => x.Id == contactId)?.ContactPhones.ToList();
                return contactPhones;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessCreateContactPhone(int contactId, int? areaCode, int? phone, int? phoneTypeId)
        {
            try
            {
                var contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == contactId);
                if (contact == null)
                    return false;

                PhoneType phoneType = null;
                if (phoneTypeId != null)
                    phoneType = _dbContext.PhoneTypes.FirstOrDefault(x => x.Id == phoneTypeId);

                var contactPhone = new ContactPhone()
                {
                    ContactId = contact.Id,
                    AreaCode = areaCode,
                    Phone = phone,
                    PhoneType = phoneType
                };

                contact.ContactPhones.Add(contactPhone);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessUpdateContactPhone(int id, int? areaCode, int? phone, int? phoneTypeId)
        {
            try
            {
                var contactPhone = _dbContext.ContactPhones.FirstOrDefault(x => x.Id == id);
                if (contactPhone == null)
                    return false;

                PhoneType phoneType = null;
                if (phoneTypeId != null)
                    phoneType = _dbContext.PhoneTypes.FirstOrDefault(x => x.Id == phoneTypeId);

                contactPhone.AreaCode = areaCode;
                contactPhone.Phone = phone;
                contactPhone.PhoneType = phoneType;

                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessDeleteContactPhone(int id)
        {
            try
            {
                var contactPhone = _dbContext.ContactPhones.FirstOrDefault(x => x.Id == id);
                if (contactPhone == null)
                    return false;

                _dbContext.ContactPhones.Remove(contactPhone);
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
