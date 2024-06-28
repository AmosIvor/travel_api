using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("PlanDetail")]
    public class PlanDetail
    {
        [Key]
        public int PlanDetailId { get; set; }

        public string? PlanDetailDescription { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public int TravelPlanId { get; set; }

        [ForeignKey("PlanId")]
        public virtual TravelPlan TravelPlan { get; set; }
    }
}
