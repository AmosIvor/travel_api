using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;

        public int CommentTotalLike { get; set; }

        [Required]
        public string CommentContent { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public virtual ICollection<CommentMedia> CommentMedias { get; set; }
    }
}
