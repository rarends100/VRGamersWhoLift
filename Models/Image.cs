using System.ComponentModel.DataAnnotations.Schema;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models
{
    public class Image
    {

        public Image() {
            ImagePath = "";
            ImageType = "";
        }
        public Image(string imagePath, string imageType, User user)
        {
            ImagePath = imagePath;
            ImageType = imageType;
            this.user = user;
        }

        public Image(string imagePath, string imageType)
        {
            ImagePath = imagePath;
            ImageType = imageType;

        }

        public string ImagePath { get; set; }
        public string ImageType { get; set; } // p = profile, g = gallery

        //PK
        public int ImageID { get; set; } = -1000; //covered by auto-increment

        public User user { get; set; } = null!;

    }
}
