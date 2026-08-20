using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.ViewModels;
using VRGamersWhoLift.Helpers;

namespace VRGamersWhoLift.Controllers
{
    public class CommentController : Controller
    {
        private VRGamersWhoLiftContext context;

        public CommentController(VRGamersWhoLiftContext _Context)
        {
            context = _Context;

        }
        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")] //pg654 Murach's ASP.NET Core MVC,  2nd Edition and //https://learn.microsoft.com/en-us/aspnet/core/mvc/security/authorization/roles?view=aspnetcore-10.0
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

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);
            return View("/Views/Profile/Profile.cshtml", profileViewModel);
        }

        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public IActionResult DeleteComment(int commentID)
        {
            if (ModelState.IsValid)
            {
                Comment comment = context.Comment.Find(commentID)!;

                context.Remove(comment);
                context.SaveChanges();
            }

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);
            return View("/Views/Profile/Profile.cshtml", profileViewModel);

           

        }

        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public IActionResult UpdateComment(string newCommentText, int commentID)
        {
            if (ModelState.IsValid)
            {
                Comment comment = context.Comment.Find(commentID)!;

                comment.Text = newCommentText;
                context.SaveChanges();
            }


            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);
            return View("/Views/Profile/Profile.cshtml", profileViewModel);
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
