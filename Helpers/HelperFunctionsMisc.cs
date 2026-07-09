using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.ViewModels;

using VRGamersWhoLift.Helpers;
using Microsoft.Data.SqlClient;

namespace VRGamersWhoLift.Helpers
{
    public class HelperFunctionsMisc
    {


        //Call anytime the profile displayed values need to be updated.
        public static ProfileViewModel PopulateProfileData(VRGamersWhoLiftContext context)
        {
            ProfileViewModel profile = new ProfileViewModel();

            try
            {
                profile.Picture = context.Image.Where(i => i.ImageType.Contains(ImageTypeOpts.p.ToString())).Select(i => i.ImagePath).FirstOrDefault();
            }
            catch(SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("\n\n SQLException: \n" + ex.Message + "\n\n");
            }
            
            return profile;

        }
       
    }
}
