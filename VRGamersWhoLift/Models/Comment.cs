using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRGamersWhoLift.Models
{
    public class Comment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string UserID { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public Post Post { get; set; } = null!;

    }
}
