namespace VRGamersWhoLift.Models.users
{
    public class Coach : BaseUser
    {
        public Coach()
        {
            UserName = "";
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
        }
        public Coach(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Role, string Password)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
        }
        public Coach(string UserName, string FirstName, string MiddleName, string LastName, string Email, string Role, string Password, Profile Profile)
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
