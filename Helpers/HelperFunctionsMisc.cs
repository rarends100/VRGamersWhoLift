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

            //UserName
            profile.UserName = HttpContext.User.Identity!.Name!; //It COULD be null sure, but it never will be with the order of execution I have setup.
            //id
            if(profile.UserName != null )
            {
                profile.UserId = context.User.Where(u => u.UserName!.Contains(profile.UserName)).Select(u => u.Id).FirstOrDefault()!;
            }
           

            try
            {
                //Profile picture
                string pic = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.p.ToString())).Where(i => i.UserId.Contains(profile.UserId)).Select(i => i.ImagePath).FirstOrDefault()!;
                if(pic != null)
                {
                    pic = pic.Replace("\\", "/");
                    profile.Picture = pic;
                }
                else
                {
                    profile.Picture = "/UserPhotos/default/default_pic.jpg"; //DEFAULT profile picture for all profiles — May or may not later when the project is fully functional add a differention based on gender.
                }


                string banner = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.b.ToString())).Where(i => i.UserId.Contains(profile.UserId)).Select(i => i.ImagePath).FirstOrDefault()!;//It COULD be null sure, but it doesn't matter.
                if (banner != null)
                {
                    pic = pic.Replace("\\", "/");
                    profile.Banner = banner;
                }
                else
                {
                    profile.Banner = ""; //possible TODO: could add a DEFAULT here
                }

                profile.FirstName = context.Profile.Where(p => p.ProfileUsernameID.Contains(profile.UserName!)).Select(p => p.FirstName).FirstOrDefault()!;
                profile.MiddleName = context.Profile.Where(p => p.ProfileUsernameID.Contains(profile.UserName!)).Select(p => p.MiddleName).FirstOrDefault()!;
                profile.LastName = context.Profile.Where(p => p.ProfileUsernameID.Contains(profile.UserName!)).Select(p => p.LastName).FirstOrDefault()!;

                //First, Middle, and Last name — May be null, doesn't patter if it is — also, within the architecture I have created it basically never will be.
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
