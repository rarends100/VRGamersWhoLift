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
                pic = pic.Replace("\\", "/");

                profile.Picture = pic;

                //UserName
                profile.UserName = HttpContext.User.Identity.Name;

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
