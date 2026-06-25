using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models.users
{
    public class BaseUser : User
    {
        public BaseUser()
        {
            //super();
            UserName = "";
        }
        public BaseUser(string UserName)
        {
            this.UserName = UserName;
        }
        public BaseUser(string UserName, string Email)
        {
            this.UserName = UserName;
            this.Email = Email;
        }

      
    }
}
