namespace VRGamersWhoLift.Models.Abstract
{
    public abstract class User
    {

        public User()
        {
            userID = string.Empty;
            firstName = string.Empty;
            middleName = string.Empty;
            lastName = string.Empty;
            email = string.Empty;
            password = string.Empty;
            userType = string.Empty;
        }

        private string userID { get; set; }
        private string firstName { get; set; }
        private string middleName { get; set; }
        private string lastName { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private string userType {  get; set; }


    }
}
