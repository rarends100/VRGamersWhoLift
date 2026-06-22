using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models.users
{
    public class BaseUser : User
    {
        public BaseUser()
        {
            //super();
            UserName = "";
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            Profile = null!;
        }
        public BaseUser(string UserName)
        {
            this.UserName = UserName;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            Profile = null!;
        }
        public BaseUser(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Password, Profile Profile)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Profile = Profile;
        }

      
    }
}
