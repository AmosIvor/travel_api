using travel_api.Models.EF;

namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class TravelPlanVM
    {
        public string? PlanName { get; set; }
        public string? UserId { get; set; }
        public virtual ICollection<PlanDetail>? PlanDetails { get; set; }
    }
}
