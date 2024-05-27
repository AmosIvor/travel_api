using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public DateTime PostDate { get; set; } = new DateTime();

        public int PostTotalLike { get; set; }

        [Required]
        public string PostContent { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public virtual ICollection<PostMedia> PostMedias { get; set; }
    }
}
