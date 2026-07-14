using Microsoft.AspNetCore.Mvc;

namespace VRGamersWhoLift.Controllers
{
    public class PostController : Controller
    {
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


    }
}
