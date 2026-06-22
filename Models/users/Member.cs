namespace VRGamersWhoLift.Models.users
{
    public class Member : BaseUser
    {
        public Member()
        {
            UserName = "";
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
        }
        public Member(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Role, string Password)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
        }
        public Member(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Role, string Password, Profile Profile)
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
