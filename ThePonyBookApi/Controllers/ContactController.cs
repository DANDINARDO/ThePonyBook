using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.ViewModels.InputModels;

namespace ThePonyBookApi.Controllers
{
    public class ContactController : ApiController
    {
        private IDbContext _dbContext;
        public ContactController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
   
        [HttpGet]
        [Route("contact")]
        public IEnumerable<Contact> GetContacts(string email)
        {
            try
            {
                var contacts = _dbContext.Contacts.Where(x => x.AspNetUser.Email == email);
                return contacts;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        [HttpPut]
        [Route("contact")]
        public bool CreateContact(ApiCreateContactInputModel inputModel)
            {
                try
                {
                    var aspNetUser = _dbContext.AspNetUsers.FirstOrDefault(x => x.Email == inputModel.Email);
                    if (aspNetUser == null)
                        return false;

                    var contact = new Contact(){ Email = inputModel.Email, FirstName = inputModel.FirstName, LastName = inputModel.LastName
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

        [HttpPost]
        [Route("contact")]
        public bool UpdateContact(ApiUpdateContactInputModel inputModel)
        {
            try
            {
                var contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == inputModel.Id);
                if (contact == null)
                    return false;

                contact.Email = inputModel.Email;
                contact.FirstName = inputModel.FirstName;
                contact.LastName = inputModel.LastName;

                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        [HttpDelete]
        [Route("contact")]
        public bool DeleteContact(int id)
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
    }
}
