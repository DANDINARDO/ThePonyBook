using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ThePonyBookLibraries.Services.Interfaces;
using ThePonyBookLibraries.ViewModels.Country;

namespace ThePonyBookApi.Controllers
{
    public class CountryController : ApiController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("countries")]
        public IEnumerable<ApiCountryViewModel> GetCountries()
        {
            return Mapper.Map<IEnumerable<ApiCountryViewModel>>(_countryService.GetCountries());
        }

    }
}
