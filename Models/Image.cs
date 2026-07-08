using System.ComponentModel.DataAnnotations.Schema;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models
{
    public class Image
    {

        public string ImagePath { get; set; }
        public string ImageType { get; set; } // p = profile, g = gallery

        //PK
        public int ImageID { get; set; }
        public User User { get; set; } = null!;

    }
}
