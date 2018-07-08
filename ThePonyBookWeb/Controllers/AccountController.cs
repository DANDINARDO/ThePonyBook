using System.Web.Mvc;
using ThePonyBookLibraries.Web.BaseControllers;
using ThePonyBookLibraries.Identity;

namespace ThePonyBookWeb.Controllers
{
    [Authorize]
    public class AccountController : AccountControllerBase
    {
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager ) : base(userManager, signInManager)
        {         
        }
    }
}