using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IPhoneTypeService
    {
        /// <summary>
        /// Get all Phone Types
        /// </summary>
        /// <returns>IEnumerable of PhoneType Objects</returns>
        IEnumerable<PhoneType> GetCPhoneTypes();
    }
}