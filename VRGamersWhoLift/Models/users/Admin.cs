using System.ComponentModel.DataAnnotations;

namespace VRGamersWhoLift.Models.users
{
    public class Admin : BaseUser
    {
        public Admin()
        {
            EmployeeID = string.Empty;
        }
        public Admin(string UserName, string Email, string EmployeeID)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.EmployeeID = EmployeeID;

        }
        public Admin(string UserName, string Email)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.EmployeeID = "Not Listed Yet";
        }

        [Required (ErrorMessage = "An Admistrator must have an employee ID.")]
        private string EmployeeID {  get; set; }
    }
}
