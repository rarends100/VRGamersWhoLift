using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models.database;

using VRGamersWhoLift.Models;


namespace VRGamersWhoLift.Controllers
{
    public class ProfileController : Controller
    {
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
        public IActionResult ProfilePhotoUpdate()
        {

            System.Diagnostics.Debug.WriteLine("Hit Profile photo update function");

            
            return View("Profile");
        }

    }
}
