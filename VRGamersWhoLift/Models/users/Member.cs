namespace VRGamersWhoLift.Models.users
{
    public class Member : BaseUser
    {
        public Member()
        {
            UserName = "";
        }
        public Member(string UserName,string Email)
        {
            this.UserName = UserName;
            this.Email = Email;

        }
        public Member(string UserName, string Password, Profile Profile)
        {
            this.UserName = UserName;
            this.Email = Email;
        }

    }
}
