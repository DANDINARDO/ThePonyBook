using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _dbContext;

        public UserService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AspNetUser> GetAllUsers()
        {
            return RetrieveAllUsers();
        }

        public AspNetUser GetUserByEmail(string email)
        {
            return RetriveUserByEmail(email);
        }

        private IEnumerable<AspNetUser> RetrieveAllUsers()
        {
            try
            {
                var users = _dbContext.AspNetUsers.ToList();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private AspNetUser RetriveUserByEmail(string email)
        {
            try
            {
                var user = _dbContext.AspNetUsers.FirstOrDefault(x => x.Email == email);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
