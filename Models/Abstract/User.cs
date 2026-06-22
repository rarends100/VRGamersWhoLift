using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VRGamersWhoLift.Models.Abstract
{
    public abstract class User : IdentityUser // Inherits all IdentityUser properties
    {

        public User()
        {
            UserName = "";
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            Profile = null!;
        }

        public User(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Password, Profile Profile)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Profile = Profile;
        }

        public override string? UserName { get => base.UserName; set => base.UserName = value; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        [NotMapped] //Must code so EF Core doesn't create a RoleNames col in the AspNetUsers table
        public string RoleNames {  get; set; } //pg 680 -> seeded in ConfigureIdentity.cs

        //one to one - one -> Navigation prop (this is how EF knows the rel since it is code first by design)
        public Profile Profile { get; set; }



    }
}
