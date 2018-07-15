using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface ICountryService
    {
        /// <summary>
        /// Get countries
        /// </summary>
        /// <returns>IEnumerable of Country Objects</returns>
        IEnumerable<Country> GetCountries();
    }
}