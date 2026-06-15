using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models.users
{
    public class Admin : User
    {
        public Admin() {
            employeeID = string.Empty;
        }
        private string employeeID {  get; set; }
    }
}
