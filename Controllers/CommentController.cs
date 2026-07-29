using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.ViewModels;

namespace VRGamersWhoLift.Controllers
{
    public class CommentController : Controller
    {
        private VRGamersWhoLiftContext context;
        public CommentController(VRGamersWhoLiftContext _Context)
        {
            context = _Context;

        }
        public IActionResult AddComment (string commentText, int postId)
        {
            Comment comment = new Comment();
            comment.Text = commentText;
            comment.PostId = postId;

            string username = HttpContext.User.Identity!.Name!;

            if(username != null)
            {
                comment.UserID = context.User.Where(u => u.UserName!.Contains(username)).Select(u => u.Id).FirstOrDefault()!;
            }

            context.Comment.Add(comment);
            context.SaveChanges();

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileData(context, HttpContext);
            return View("/Views/Profile/Profile.cshtml", profileViewModel);
        }

        public IActionResult DeleteComment(int commentID)
        {
            if (ModelState.IsValid)
            {
                Comment comment = context.Comment.Find(commentID)!;

                context.Remove(comment);
                context.SaveChanges();
            }

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileData(context, HttpContext);
            return View("/Views/Profile/Profile.cshtml", profileViewModel);

           

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
