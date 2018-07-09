using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ThePonyBookLibraries.Web.BaseControllers;
using ThePonyBookLibraries.Identity;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookWeb.Controllers
{
    [Authorize]
    public class AccountController : AccountControllerBase
    {
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IUserService userService) : base(userManager, signInManager, userService)
        {         
        }
    }
}