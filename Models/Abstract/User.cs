namespace VRGamersWhoLift.Models.Abstract
{
    public abstract class User
    {

        public User()
        {
            UserID = string.Empty;
            UserFirstName = string.Empty;
            UserMiddleName = string.Empty;
            UserLastName = string.Empty;
        }

        private string UserID { get; set; }
        private string UserFirstName { get; set; }
        private string UserMiddleName { get; set; }
        private string UserLastName { get; set; }

    }
}
