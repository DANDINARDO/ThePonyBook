using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class PhoneTypeService : IPhoneTypeService
    {
        private readonly IDbContext _dbContext;

        #region Constructors 

        public PhoneTypeService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<PhoneType> GetCPhoneTypes()
        {
            return RetrievePhoneTypes();
        }

        #endregion

        #region Private Methods

        private IEnumerable<PhoneType> RetrievePhoneTypes()
        {
            try
            {
                var phontTypes = _dbContext.PhoneTypes.ToList();
                return phontTypes;
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
