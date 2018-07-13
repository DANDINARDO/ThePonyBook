using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ThePonyBookLibraries.Services.Interfaces;
using ThePonyBookLibraries.ViewModels.ContactPhone;
using ThePonyBookLibraries.ViewModels.InputModels.ContactAddress;
using ThePonyBookLibraries.ViewModels.InputModels.ContactPhone;

namespace ThePonyBookApi.Controllers
{
    public class ContactPhoneController : ApiController
    {
        private readonly IContactPhoneService _contactPhoneService;

        public ContactPhoneController(IContactPhoneService contactPhoneService)
        {
            _contactPhoneService = contactPhoneService;
        }

        [HttpGet]
        [Route("contactphone")]
        public IEnumerable<ApiContactPhoneViewModel> GetContactPhones(int contactId)
        {
            return Mapper.Map<IEnumerable<ApiContactPhoneViewModel>>(_contactPhoneService.GetContactPhones(contactId));
        }

        [HttpPut]
        [Route("contactphone")]
        public bool CreateContactPhone(ApiCreateContactPhoneInputModel inputModel)
        {
            return _contactPhoneService.CreateContactPhone(inputModel.ContactId, inputModel.AreaCode, inputModel.Phone, inputModel.PhoneTypeId);
        }

        [HttpPost]
        [Route("contactphone")]
        public bool UpdateContactPhone(ApiUpdateContactPhoneInputModel inputModel)
        {
            return _contactPhoneService.UpdateContactPhone(inputModel.Id, inputModel.AreaCode, inputModel.Phone, inputModel.PhoneTypeId); ;
        }

        [HttpDelete]
        [Route("contactphone")]
        public bool DeleteContactPhone(int id)
        {
            return _contactPhoneService.DeleteContactPhone(id);
        }
    }
}
