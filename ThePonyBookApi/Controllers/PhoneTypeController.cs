using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ThePonyBookLibraries.Services.Interfaces;
using ThePonyBookLibraries.ViewModels.PhoneType;

namespace ThePonyBookApi.Controllers
{
    public class PhoneTypeController : ApiController
    {
        private readonly IPhoneTypeService _phoneTypeService;

        public PhoneTypeController(IPhoneTypeService phoneTypeService)
        {
            _phoneTypeService = phoneTypeService;
        }

        [HttpGet]
        [Route("phonetypes")]
        public IEnumerable<ApiPhoneTypeViewModel> GetCountries()
        {
            return Mapper.Map<IEnumerable<ApiPhoneTypeViewModel>>(_phoneTypeService.GetCPhoneTypes());
        }

    }
}
