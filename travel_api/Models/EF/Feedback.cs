using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public DateTime FeedbackDate { get; set; } = new DateTime();

        [Required]
        public string FeedbackContent { get; set; }

        public int FeedbackRate { get; set; }

        public int TripType { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public virtual ICollection<FeedbackMedia> FeedbackMedias { get; set; }
    }
}
