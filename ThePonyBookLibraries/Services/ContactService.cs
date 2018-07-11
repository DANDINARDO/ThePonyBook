﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class ContactService : IContactService
    {
        private readonly IDbContext _dbContext;

        #region Constructors 

        public ContactService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Contact> GetContacts(string email)
        {
            return RetrieveContacts(email);
        }

        public bool CreateContact(string email, string firstName, string lastName)
        {
            return ProcessCreateContact(email, firstName, lastName);
        }

        public bool UpdateContact(int id, string email, string firstName, string lastName)
        {
            return ProcessUpdateContact(id, email, firstName, lastName);
        }

        public bool DeleteContact(int id)
        {
            return ProcessDeleteContact(id);
        }

        #endregion

        #region Private Methods

        private IEnumerable<Contact> RetrieveContacts(string email)
        {
            try
            {
                var contacts = _dbContext.Contacts.Where(x => x.AspNetUser.Email == email).Include(x => x.AspNetUser).Include(x => x.ContactAddresses).Include(x => x.ContactPhones).ToList();
                return contacts;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessCreateContact(string email, string firstName, string lastName)
        {
            try
            {
                var aspNetUser = _dbContext.AspNetUsers.FirstOrDefault(x => x.Email == email);
                if (aspNetUser == null)
                    return false;

                var contact = new Contact()
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
                aspNetUser.Contacts.Add(contact);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessUpdateContact(int id, string email, string firstName, string lastName)
        {
            try
            {
                var contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
                if (contact == null)
                    return false;

                contact.Email = email;
                contact.FirstName = firstName;
                contact.LastName = lastName;

                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessDeleteContact(int id)
        {
            try
            {
                var contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
                if (contact == null)
                    return false;
                _dbContext.Contacts.Remove(contact);
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
