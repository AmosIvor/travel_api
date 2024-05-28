using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("FeedbackMedia")]
    public class FeedbackMedia
    {
        [Key]
        public int FeedbackMediaId { get; set; }

        public int FeedbackMediaOrder { get; set; }

        public string FeedbackMediaUrl { get; set; }

        public int FeedbackId { get; set; }

        [ForeignKey("FeedbackId")]
        public virtual Feedback Feedback { get; set; }
    }
}
