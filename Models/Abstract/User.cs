using System.ComponentModel.DataAnnotations;

namespace VRGamersWhoLift.Models.Abstract
{
    public abstract class User
    {

        public User()
        {
            UserID = -1;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            UserType = string.Empty;
        }

        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        public string UserType {  get; set; }


    }
}
