using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("TravelPlan")]
    public class TravelPlan
    {
        [Key]
        public string? PlanId { get; set; }
        public string? PlanName { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public virtual ICollection<PlanDetail>? PlanDetails { get; set; }
    }
}
