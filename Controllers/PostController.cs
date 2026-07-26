using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models.database;

namespace VRGamersWhoLift.Controllers
{
    public class PostController : Controller
    {

        private VRGamersWhoLiftContext context;
        private HttpContext httpContext { get; set; }
        public PostController(VRGamersWhoLiftContext _Context, HttpContext _HttpContext)
        {
            context = _Context;
            httpContext = _HttpContext;

        }


        public IActionResult AddPost()
        {
            //TODO write methods
            return View("Profile");
        }

        public IActionResult DeletePost()
        {
            return View("Profile");
        }

        public IActionResult UpdatePost()
        {
            return View("Profile");
        }

        public IActionResult GetPost()
        {
            return View("Profile");
        }

        public IActionResult GetOtherUsersPost()
        {
            //TODO: Only write this method after the functionality to view another users profile is completed in it's most basic way.
            return View("Profile");
        }

    }
}
