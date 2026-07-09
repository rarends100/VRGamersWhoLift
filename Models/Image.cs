using System.ComponentModel.DataAnnotations.Schema;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models
{
    public class Image
    {

        public Image(string imagePath, string imageType, int imageID, User user)
        {
            ImagePath = imagePath;
            ImageType = imageType;
            ImageID = imageID;
            User = user;
        } 

        public string ImagePath { get; set; }
        public string ImageType { get; set; } // p = profile, g = gallery

        //PK
        public int ImageID { get; set; }
        public User User { get; set; } = null!;

    }
}
