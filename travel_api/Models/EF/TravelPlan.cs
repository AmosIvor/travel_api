using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("TravelPlan")]
    public class TravelPlan
    {
        [Key]
        public int TravelPlanId { get; set; }
        public string? TravelPlanName { get; set; }
        public DateTime PlanCreateAt { get; set; } = DateTime.Now;
        public DateTime TravelDate { get; set; } = DateTime.Now;
        public string? TravelDescription { get; set; }
        public string? TravelUrl { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<PlanDetail> PlanDetails { get; set; }
    }
}
