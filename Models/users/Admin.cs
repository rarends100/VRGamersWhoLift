using System.ComponentModel.DataAnnotations;

namespace VRGamersWhoLift.Models.users
{
    public class Admin : BaseUser
    {
        public Admin()
        {
            EmployeeID = string.Empty;
        }
        public Admin(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Password, Profile Profile, string EmployeeID)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Profile = Profile;
            this.EmployeeID = EmployeeID;

        }

        [Required]
        private string EmployeeID {  get; set; }
    }
}
