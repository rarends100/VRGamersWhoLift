using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models.database;

using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.users;

using VRGamersWhoLift.Helpers;

using System;
using System.IO;
using System.Text;


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
        [HttpPost]
        public  IActionResult ProfilePhotoUpdate(IFormFile image)
        {

            System.Diagnostics.Debug.WriteLine("Hit Profile photo update function");

            List<string> errors = new List<string>();

            




            if(image == null)
            {
                errors.Add("No photo selected.");
                ViewBag.Errors = errors;
                return View("Profile");
                
            }
            else
            {
                //Get the current logged in user — The user that wants to add the photo
                string UserName = HttpContext.User.Identity.Name;

                var loggedInUser = context.Users.Where(u => u.UserName.Contains(UserName)).ToList();

                //create file path relative to server wwwroot dir https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-10.0
                string filePath = ".\\..\\wwwroot\\UserPhotos\\" + UserName + "\\" + image.FileName; //move one up from Controller dir (current dir) to the wwwroot dir (safe for storing user files dir)

                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
               
                //Add the file, if file is good, then do the rest and insert the new image entry https://www.w3schools.com/cs/cs_files.php



                BaseUser CurrentUser = new BaseUser();
                CurrentUser.UserName = UserName;
                CurrentUser.Id = loggedInUser[0].Id;

                //Does this profile pic already exist?
                var isProfilePic = context.Image.Where(i => i.ImagePath.Contains(filePath)).Where(i => i.ImageType.Contains(ImageTypeOpts.p.ToString())).ToList();

                if (isProfilePic.Count() > 0) 
                {
                    Image picture = new Image(filePath, ImageTypeOpts.p.ToString());
                    context.Image.Update(picture);

                    //must use fully qualified name since theree is a file method in the Controller class that all controllers inherit, annoying
                }
                else
                {
                    Image picture = new Image(filePath, ImageTypeOpts.p.ToString());
                    context.Image.Add(picture);
                    

                }

                try
                {
                    //https://stackoverflow.com/questions/39322085/how-to-save-iformfile-to-disk
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }


                    //Creates or replaces a file //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-10.0
                }
                catch(IOException ex)
                {
                    System.Diagnostics.Debug.WriteLine("\n\n IOException: \n" + ex + "\n\n" );

                }






            }

                return View("Profile");
        }

    }
}
