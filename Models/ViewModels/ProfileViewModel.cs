namespace VRGamersWhoLift.Models.ViewModels
{
    public class ProfileViewModel
    {

        public string Picture { get; set; } = null!; //profile picture
        public string UserName { get; set; } = null!;
        public List<string> gallery { get; set; } = null!; //pictures in the gallery for the specified user

        //Will likely add more fields like posts and stuff as I continue the design of this webpage
    }
}
