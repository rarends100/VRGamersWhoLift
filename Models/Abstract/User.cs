using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VRGamersWhoLift.Models.Abstract
{
    public abstract class User : IdentityUser // Inherits all IdentityUser properties
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable. -> I know that RoleNames must not be null, covered by the Identity framework and UserViewModel
        public User()
        {
            UserName = "";
            Profile = null!;
        }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public User(string UserName, string Email,  Profile Profile)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.Profile = Profile;
        }

        /*[NotMapped]
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }*/ //Now covered by the view model to ensure Identity framework works as intended by Microsoft

        [NotMapped] //Must code so EF Core doesn't create a RoleNames col in the AspNetUsers table
        public string RoleNames {  get; set; } //pg 680 -> seeded in ConfigureIdentity.cs

        //one to one - one -> Navigation prop (this is how EF knows the rel since it is code first by design)
        [NotMapped]
        public Profile Profile { get; set; }

        [NotMapped]
        //one user to many images — nav prop
        public List<Image> Images { get; set; } = null!;


    }
}
