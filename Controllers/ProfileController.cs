using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models.database;

using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.users;
using Microsoft.AspNetCore.Identity;


namespace VRGamersWhoLift.Controllers
{
    public class ProfileController : Controller
    {
        //Get dependencie injections 
        private readonly VRGamersWhoLiftContext context;
        public ProfileController(VRGamersWhoLiftContext _context)
        { 
            context = _context;
        }

        [HttpGet]
        public IActionResult Profile()
        {

            
            return View();
        }

        //https://learn.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/9-working-with-images
        public  IActionResult ProfilePhotoUpdate(IFormFile image)
        {

            System.Diagnostics.Debug.WriteLine("Hit Profile photo update function");

            List<string> errors = new List<string>();

            ViewBag.Errors = errors;

            if(image == null)
            {
                errors.Add("No photo selected.");
                return View("Profile");
            }
            else
            {
                //Get the current logged in user — The user that wants to add the photo
                string UserName = HttpContext.User.Identity.Name;
                
                //create file path relative to server wwwroot dir https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-10.0
                string filePath = "~\\wwwroot\\UserPhotos\\" + "";


                Image profilePicture = new Image();
                profilePicture.ImagePath = "";

            }

                return View("Profile");
        }

    }
}
