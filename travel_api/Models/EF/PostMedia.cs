using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("PostMedia")]
    public class PostMedia
    {
        [Key]
        public int PostMediaId { get; set; }

        public int PostMediaOrder { get; set; }

        public string PostMediaUrl { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
