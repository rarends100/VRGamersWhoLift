using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AuthenticationController(UserManager<User> userMngr, SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        //TODO: Register, login, and Logout methods here

        public IActionResult Register()
        {
            return View();
        }
    }
}
