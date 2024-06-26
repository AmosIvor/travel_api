using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("PlanDetail")]
    public class PlanDetail
    {
        [Key]
        public int Id { get; set; }
        public string? PlanId { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }

        [ForeignKey("PlanId")]
        public TravelPlan? TravelPlan { get; set; }
    }
}
