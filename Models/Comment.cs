namespace VRGamersWhoLift.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string text { get; set; }

        public Post Post { get; set; } = null!;

    }
}
