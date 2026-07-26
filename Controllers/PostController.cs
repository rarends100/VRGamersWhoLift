using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Helpers;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VRGamersWhoLift.Controllers
{
    public class PostController : Controller
    {

        private VRGamersWhoLiftContext context;
        public PostController(VRGamersWhoLiftContext _Context)
        {
            context = _Context;

        }


        public IActionResult AddPost(string postTextContent)
        {
            //TODO write method
            string postText = postTextContent;
            string username = HttpContext.User.Identity!.Name!;

            Post post = new Post();

            post.ImageId = 1; //TODO: fix this later so that the image ID will be either the new image added or an image that already exists to satisfy the Post tables FK x => x.ImageID requirement with the Image table
            post.PostText = postText;
            
            //add the userID to the post ------
            if (username != null)
            {
                post.UserId = context.User.Where(u => u.UserName!.Contains(username)).Select(u => u.Id).FirstOrDefault()!;
            }
            //add the userID to the post end ------

            context.Post.Add(post);
            context.SaveChanges();

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileData(context, HttpContext);
            return View("/Views/Profile/Profile.cshtml", profileViewModel);
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
