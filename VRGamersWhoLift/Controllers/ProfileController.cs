using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VRGamersWhoLift.Helpers;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.users;
using VRGamersWhoLift.Models.ViewModels;


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

        //Init load profile
        [HttpGet]
        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public IActionResult Profile()
        {
            ProfileViewModel model = HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);
            model.Errors = new List<string>();
            
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public IActionResult ViewOtherProfile()
        {
            //TODO: populate this with necessary logic to show other profile and make an other profile razor page,
            //OR if I can find out if it is possible to make the og razor page act as an other profile in a different circumstance
            //Maybe doable with decision logic in the profile.cshtml razor view
            return View();
        }




        //updates profile picture
        //https://learn.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/9-working-with-images
        [HttpPost]
        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public  IActionResult ProfilePhotoUpdate(IFormFile image)
        {

            System.Diagnostics.Debug.WriteLine("Hit Profile photo update function");
            List<string> errors = new List<string>();

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);





            if (image == null)
            {
                errors.Add("No photo selected.");
                profileViewModel.Errors = errors;
                return View("Profile", profileViewModel);
                
            }
            else
            {
                //Get the current logged in user — The user that wants to add the photo
                //string UserName = HttpContext.User.Identity.Name; //Now handled by the ProfileViewModel

                var loggedInUser = context.Users.Where(u => u.UserName!.Contains(profileViewModel.UserName)).ToList();

                //string appRoot = AppContext.BaseDirectory;

                //create file path relative to server wwwroot dir https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-10.0
                string fullFilePath = ".\\wwwroot\\UserPhotos\\" + profileViewModel.UserName + "\\" + image.FileName; //move one up from Controller dir (current dir) to the wwwroot dir (safe for storing user files dir)
                string dbEntryPath = "\\UserPhotos\\" + profileViewModel.UserName + "\\" + image.FileName; //The path that will be called by img elements

                string directoryPath = Path.GetDirectoryName(fullFilePath)!;
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
               
                //Add the file, if file is good, then do the rest and insert the new image entry https://www.w3schools.com/cs/cs_files.php



                BaseUser CurrentUser = new BaseUser();
                CurrentUser.UserName = profileViewModel.UserName;
                CurrentUser.Id = loggedInUser[0].Id;

                //Does this profile pic already exist?
                var isProfilePic = context.Image.Where(i => i.UserId.Contains(CurrentUser.Id)).Where(i => i.ImageType.Contains(ImageTypeOpts.p.ToString())).ToList();

                if (isProfilePic.Count() > 0) 
                {
                    Image picture = new Image(dbEntryPath, ImageTypeOpts.p.ToString(), CurrentUser.Id);

                    try
                    {

                        ///https://learn.microsoft.com/en-us/ef/core/performance/efficient-updating?tabs=ef7
                        //pg 148 Murach ASP.NET Core MVC 2nd Edition
                        IQueryable<Image> selectedImage = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.p.ToString())).Where(i => i.UserId.Contains(CurrentUser.Id));
                        picture.ImageID = (int) selectedImage.Select(i => i.ImageID).FirstOrDefault();
                        context.Image
                            .Where(i => i.ImageID == picture.ImageID)
                            .ExecuteUpdate(setters => setters.SetProperty(i => i.ImagePath, dbEntryPath)); //https://learn.microsoft.com/en-us/ef/core/saving/execute-insert-update-delete
                        context.SaveChanges(); //NOTE: Users can only have 1 profile photo — This is by design
                    }catch(SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("\n\n SQLException: \n" + ex + "\n\n");
                    }
                    

                    //must use fully qualified name since theree is a file method in the Controller class that all controllers inherit, annoying
                }
                else
                {
                    Image picture = new Image(dbEntryPath, ImageTypeOpts.p.ToString(), CurrentUser.Id);
                    try
                    {
                        context.Image.Add(picture);
                        context.SaveChanges(); //NOTE to SELF — do NOT forget this after making changes to the DB in EF Core

                        //https://stackoverflow.com/questions/39322085/how-to-save-iformfile-to-disk
                        using (Stream fileStream = new FileStream(fullFilePath, FileMode.Create))
                        {
                            image.CopyTo(fileStream);
                            fileStream.Close(); //close the stream to free up resources
                        }
                        //profileViewModel.Errors.Clear();

                        //Creates or replaces a file //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-10.0
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("\n\n SQLException: \n" + ex + "\n\n");
                    }
                    catch(IOException ex)
                    {
                    System.Diagnostics.Debug.WriteLine("\n\n IOException: \n" + ex + "\n\n" );
                    }

                }


            }
                //TODO: solve bug where even though the new profile picture is updated, the old profile picture is not deleted, alternatively I could just assign it to the gallery
                profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);


                return View("Profile", profileViewModel);
        }

        //Updates profile banner
        [HttpPost]
        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public IActionResult ProfileBannerUpdate(IFormFile image)
        {
            System.Diagnostics.Debug.WriteLine("Hit Profile photo update function");
            List<string> errors = new List<string>();

            ProfileViewModel profileViewModel = Helpers.HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);


            if (image == null)
            {
                errors.Add("No photo selected.");
                profileViewModel.Errors = errors;
                return View("Profile", profileViewModel);

            }
            else
            {
                //Get the current logged in user — The user that wants to add the photo
                //string UserName = HttpContext.User.Identity.Name; //Now handled by the ProfileViewModel

                var loggedInUser = context.Users.Where(u => u.UserName!.Contains(profileViewModel.UserName)).ToList();

                //string appRoot = AppContext.BaseDirectory;

                //create file path relative to server wwwroot dir https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-10.0
                string fullFilePath = ".\\wwwroot\\UserPhotos\\" + profileViewModel.UserName + "\\" + image.FileName; //move one up from Controller dir (current dir) to the wwwroot dir (safe for storing user files dir)
                string dbEntryPath = "\\UserPhotos\\" + profileViewModel.UserName + "\\" + image.FileName; //The path that will be called by img elements

                string directoryPath = Path.GetDirectoryName(fullFilePath)!;
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //Add the file, if file is good, then do the rest and insert the new image entry https://www.w3schools.com/cs/cs_files.php



                BaseUser CurrentUser = new BaseUser();
                CurrentUser.UserName = profileViewModel.UserName;
                CurrentUser.Id = loggedInUser[0].Id;

                //Does this profile pic already exist?
                var isBannerPic = context.Image.Where(i => i.UserId.Contains(CurrentUser.Id)).Where(i => i.ImageType.Contains(ImageTypeOpts.b.ToString())).ToList();

                if (isBannerPic.Count() > 0)
                {
                    Image picture = new Image(dbEntryPath, ImageTypeOpts.b.ToString(), CurrentUser.Id);

                    try
                    {

                        ///https://learn.microsoft.com/en-us/ef/core/performance/efficient-updating?tabs=ef7
                        //pg 148 Murach ASP.NET Core MVC 2nd Edition
                        IQueryable<Image> selectedImage = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.b.ToString())).Where(i => i.UserId.Contains(CurrentUser.Id));
                        picture.ImageID = (int)selectedImage.Select(i => i.ImageID).FirstOrDefault();
                        context.Image
                            .Where(i => i.ImageID == picture.ImageID)
                            .ExecuteUpdate(setters => setters.SetProperty(i => i.ImagePath, dbEntryPath)); //https://learn.microsoft.com/en-us/ef/core/saving/execute-insert-update-delete
                        context.SaveChanges(); //NOTE: Users can only have 1 profile photo — This is by design
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("\n\n SQLException: \n" + ex + "\n\n");
                    }

                }
                else
                {
                    Image picture = new Image(dbEntryPath, ImageTypeOpts.b.ToString(), CurrentUser.Id);
                    try
                    {
                        context.Image.Add(picture);
                        context.SaveChanges(); //NOTE to SELF — do NOT forget this after making changes to the DB in EF Core

//                      // Saves File to disk
                        //https://stackoverflow.com/questions/39322085/how-to-save-iformfile-to-disk
                        using (Stream fileStream = new FileStream(fullFilePath, FileMode.Create))
                        {
                            image.CopyTo(fileStream);
                            fileStream.Close(); //close the stream to free up resources
                        }

                        //Creates or replaces a file //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-10.0
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("\n\n SQLException: \n" + ex + "\n\n");
                    }
                    catch (IOException ex)
                    {
                    System.Diagnostics.Debug.WriteLine("\n\n IOException: \n" + ex + "\n\n");
                    }

                }

            }

            profileViewModel = HelperFunctionsMisc.PopulateProfileViewModelData(context, HttpContext);

            return View("Profile", profileViewModel);
        }

    }

}
