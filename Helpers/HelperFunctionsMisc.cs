using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.ViewModels;

using VRGamersWhoLift.Helpers;
using Microsoft.Data.SqlClient;

namespace VRGamersWhoLift.Helpers
{
    public class HelperFunctionsMisc
    {


        //Call anytime the profile displayed values need to be updated. So far it populates the profile picture
        public static ProfileViewModel PopulateProfileData(VRGamersWhoLiftContext context, HttpContext HttpContext)
        {
            ProfileViewModel profile = new ProfileViewModel();

            try
            {
                //Profile picture
                string pic = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.p.ToString())).Select(i => i.ImagePath).FirstOrDefault();
                if(pic != null)
                {
                    pic = pic.Replace("\\", "/");
                    profile.Picture = pic;
                }


                string banner = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.b.ToString())).Select(i => i.ImagePath).FirstOrDefault();
                if (pic != null)
                {
                    pic = pic.Replace("\\", "/");
                    profile.Banner = banner;
                }

                //UserName
                profile.UserName = HttpContext.User.Identity.Name;

                profile.FirstName = context.Profile.Where(p => p.ProfileUsernameID.Contains(profile.UserName)).Select(p => p.FirstName).FirstOrDefault();
                profile.MiddleName = context.Profile.Where(p => p.ProfileUsernameID.Contains(profile.UserName)).Select(p => p.MiddleName).FirstOrDefault();
                profile.LastName = context.Profile.Where(p => p.ProfileUsernameID.Contains(profile.UserName)).Select(p => p.LastName).FirstOrDefault();

                //First, Middle, and Last name
                //profile.FirstName = context.Users.Where(u => u.UserName.Contains(profile.UserName)).Select(u => u.First)
            }
            catch(SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("\n\n SQLException: \n" + ex.Message + "\n\n");
            }
            
            return profile;

        }
       
    }
}
