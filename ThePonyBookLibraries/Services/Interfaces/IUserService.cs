using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>IEnumerable of AspNetUser Objects</returns>
        IEnumerable<AspNetUser> GetAllUsers();

       /// <summary>
       /// Get a User By Email
       /// </summary>
       /// <param name="email">User Email</param>
       /// <returns>AspNetUser Record</returns>
        AspNetUser GetUserByEmail(string email);
    }
}