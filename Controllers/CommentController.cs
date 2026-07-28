using Microsoft.AspNetCore.Mvc;

namespace VRGamersWhoLift.Controllers
{
    public class CommentController : Controller
    {

        public IActionResult AddComment ()
        {
            return View();
        }

        public IActionResult DeleteComment()
        {
            return View();
        }


        public IActionResult UpdateComment()
        {
            return View();
        }


        public IActionResult GetComment()
        {
            return View();
        }

        public IActionResult GetAllCommentsForUser()
        {
            return View();
        }

    }
}
