using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models
{
    public class Profile
    {
        public Profile()
        {
            ProfileUsernameID = "";
            User = null!;
        }

        //fully defined one-to-one rel by convention -> one 
        public string ProfileUsernameID { get; set; } //Username

        //Navigation prop back to User 
        public User User { get; set; }
        
        //profile specific fields -> NOTE: will include weight, PR's, daily kCal, etc soon
        public string Name { get; set; }

        
    }
}
