using VRGamersWhoLift.Models.Abstract;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRGamersWhoLift.Models
{
    public class Image
    {

        public Image() {
            ImagePath = "";
            ImageType = "";
            UserId = "";
        }
        public Image(string imagePath, string imageType, string userId, User user)
        {
            ImagePath = imagePath;
            ImageType = imageType;
            User = user;
            UserId = userId;
        }

        public Image(string imagePath, string imageType, string userId)
        {
            ImagePath = imagePath;
            ImageType = imageType;
            UserId = userId;

        }
        //PK
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //making this col autoincrement — Just makes this far easier
        public int ImageID { get; set; } //covered by auto-increment
        public string ImagePath { get; set; }
        public string ImageType { get; set; } // p = profile, g = gallery

        
        
        public string UserId { get; set; } 
        public User User { get; set; } = null!;



        public IEnumerable<Post> Post { get; set; } = null!;

    }
}
