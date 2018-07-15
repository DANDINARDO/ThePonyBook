using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class CountryService : ICountryService
    {
        private readonly IDbContext _dbContext;

        #region Contructors

        public CountryService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Country> GetCountries()
        {
            return RetrieveCountries();
        }

        #endregion

        #region Private Methods

        private IEnumerable<Country> RetrieveCountries()
        {
            try
            {
                var countries = _dbContext.Countries.ToList();
                return countries;
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
