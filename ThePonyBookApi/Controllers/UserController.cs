using System.Web.Http;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookApi.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getuser")]
        public AspNetUser GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }
    }
}
