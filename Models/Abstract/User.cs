using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VRGamersWhoLift.Models.Abstract
{
    public abstract class User : IdentityUser
    {

        public User()
        {
            UserID = -1;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            UserType = string.Empty;
            Profile = null!;
        }

        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        public string UserType {  get; set; }

        //one to one - one -> Navigation prop (this is how EF knows the rel since it is code first by design)
        public Profile Profile { get; set; }



    }
}
