using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;
using ThePonyBookLibraries.ViewModels;
using ThePonyBookLibraries.ViewModels.Contact;
using ThePonyBookLibraries.ViewModels.InputModels;

namespace ThePonyBookApi.Controllers
{
    public class ContactController : ApiController
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
   
        [HttpGet]
        [Route("contact")]
        public IEnumerable<ApiContactViewModel> GetContacts(string email)
        {
           return Mapper.Map<IEnumerable<ApiContactViewModel>>(_contactService.GetContacts(email));
        }

        [HttpPut]
        [Route("contact")]
        public bool CreateContact(ApiCreateContactInputModel inputModel)
        {
           return _contactService.CreateContact(inputModel.Email, inputModel.FirstName, inputModel.LastName);
        }

        [HttpPost]
        [Route("contact")]
        public bool UpdateContact(ApiUpdateContactInputModel inputModel)
        {
            return _contactService.UpdateContact(inputModel.Id, inputModel.Email, inputModel.FirstName, inputModel.LastName);
        }

        [HttpDelete]
        [Route("contact")]
        public bool DeleteContact(int id)
        {
            return _contactService.DeleteContact(id);
        }
    }
}
