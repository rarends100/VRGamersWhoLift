namespace VRGamersWhoLift.Models.ViewModels
{
    public class ProfileViewModel
    {

        public string Picture { get; set; } = null!; //profile picture
        public string Banner { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string> Gallery { get; set; } = null!; //pictures in the gallery for the specified user
        public List<string> Errors { get; set; } = null!;

        //Will likely add more fields like posts and stuff as I continue the design of this webpage
    }
}
