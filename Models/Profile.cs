using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models
{
    public class Profile
    {
        public Profile()
        {
            ProfileID = -1;
            Name = "no name";
            UserId = -1;
            User = null!;
        }
        public int ProfileID {  get; set; }
        

        //fully defined one-to-one rel by convention -> one 
        public int UserId { get; set; }

        //Navigation prop back to User 
        public User User { get; set; }
        
        //profile specific fields -> NOTE: will include weight, PR's, daily kCal, etc soon
        public string Name { get; set; }

        
    }
}
