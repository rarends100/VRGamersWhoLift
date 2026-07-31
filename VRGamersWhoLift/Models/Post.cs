using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRGamersWhoLift.Models
{
    public class Post
    {
        //PK
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //making this col autoincrement — Just makes this far easier
        public int PostId { get; set; }
        public string PostText { get; set; } = "";

        

        public string UserId { get; set; } = "";
        public int ImageId { get; set; } = -1;
        public Image Image { get; set; } = null!;

        public IEnumerable<Comment> Comments { get; set; } = null!;
    }
}
