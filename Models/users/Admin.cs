using System.ComponentModel.DataAnnotations;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models.users
{
    public class Admin : User
    {
        public Admin()
        {
            EmployeeID = string.Empty;
        }
        public Admin(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Role, string Password, Profile Profile, string EmployeeID)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Role = Role;
            this.Password = Password;
            this.Profile = Profile;
            this.EmployeeID = EmployeeID;

        }

        [Required]
        private string EmployeeID {  get; set; }
    }
}
