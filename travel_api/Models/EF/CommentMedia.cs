using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace travel_api.Models.EF
{
    [Table("CommentMedia")]
    public class CommentMedia
    {
        [Key]
        public int CommentMediaId { get; set; }

        public int CommentMediaOrder { get; set; }

        public string CommentMediaUrl { get; set; }

        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}
