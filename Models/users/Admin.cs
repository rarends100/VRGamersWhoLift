using System.ComponentModel.DataAnnotations;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models.users
{
    public class Admin : User
    {
        public Admin() {
            EmployeeID = string.Empty;
        }
        [Required]
        private string EmployeeID {  get; set; }
    }
}
