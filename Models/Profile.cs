using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models
{
    public class Profile
    {
        public Profile()
        {
            ProfileUsernameID = "";
            User = null!;
            FirstName = "";
            MiddleName = null!;
            LastName = "";


        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Profile(string ProfileUsernameID, string FirstName, string MiddleName, string LastName)
        {
            this.ProfileUsernameID = ProfileUsernameID;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
        }



        //fully defined one-to-one rel by convention -> one 
        public string ProfileUsernameID { get; set; } //Username

        [NotMapped]
        //Navigation prop back to User 
        public User User { get; set; }
        
        //profile specific fields -> NOTE: will include weight, PR's, daily kCal, etc soon
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } //In C#, I call getters and setters by using Properties, which act as wrappers for reading and writing data. Which is very different from Java or Javascript. Seems hard to secure honestly, in comparison to Java.
        public string MiddleName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }


    }
}
