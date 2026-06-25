namespace VRGamersWhoLift.Models.users
{
    public class Coach : BaseUser
    {
        public Coach()
        {
            UserName = "";
        }
        public Coach(string UserName, string Email)
        {
            this.UserName = UserName;
            this.Email = Email;

        }
        public Coach(string UserName, string Password, Profile Profile)
        {
            this.UserName = UserName;
            this.Email = Email;
        }
    }
}
