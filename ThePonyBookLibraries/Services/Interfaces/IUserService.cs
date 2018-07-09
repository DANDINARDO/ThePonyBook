using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<AspNetUser> GetAllUsers();
    }
}