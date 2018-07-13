using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ThePonyBookLibraries.Services.Interfaces;
using ThePonyBookLibraries.ViewModels.ContactAddress;
using ThePonyBookLibraries.ViewModels.InputModels.ContactAddress;

namespace ThePonyBookApi.Controllers
{
    public class ContactAddressController : ApiController
    {
        private readonly IContactAddressService _contactAddressService;

        public ContactAddressController(IContactAddressService contactAddressService)
        {
            _contactAddressService = contactAddressService;
        }

        [HttpGet]
        [Route("contactaddress")]
        public IEnumerable<ApiContactAddressViewModel> GetContactAddresses(int contactId)
        {
            return Mapper.Map<IEnumerable<ApiContactAddressViewModel>>(_contactAddressService.GetContactAddresses(contactId));
        }

        [HttpPut]
        [Route("contactaddress")]
        public bool CreateContactAddress(ApiCreateContactAddressInputModel inputModel)
        {
            return _contactAddressService.CreateContactAddress(inputModel.ContactId, inputModel.Address1, inputModel.Address2, inputModel.City, inputModel.Region, inputModel.PostalCode, inputModel.CountryId);
        }

        [HttpPost]
        [Route("contactaddress")]
        public bool UpdateContactAddress(ApiUpdateContactAddressInputModel inputModel)
        {
            return _contactAddressService.UpdateContactAddress(inputModel.Id, inputModel.Address1, inputModel.Address2, inputModel.City, inputModel.Region, inputModel.PostalCode, inputModel.CountryId); ;
        }

        [HttpDelete]
        [Route("contactaddress")]
        public bool DeleteContactAddress(int id)
        {
            return _contactAddressService.DeleteContactAddress(id);
        }
    }
}
