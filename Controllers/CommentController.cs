using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.database;

namespace VRGamersWhoLift.Controllers
{
    public class CommentController : Controller
    {
        private VRGamersWhoLiftContext context;
        public CommentController(VRGamersWhoLiftContext _Context)
        {
            context = _Context;

        }
        public IActionResult AddComment (string text, int postId)
        {
            Comment comment = new Comment();
            comment.Text = text;

            context.Comment.Add(comment);
            context.SaveChanges();

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
