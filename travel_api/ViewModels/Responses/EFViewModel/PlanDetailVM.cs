using travel_api.Models.EF;

namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class PlanDetailBaseVM
    {
        public int PlanDetailId { get; set; }

        public string? PlanDetailDescription { get; set; }

        public int LocationId { get; set; }

        public int TravelPlanId { get; set; }
    }

    public class PlanDetailVM : PlanDetailBaseVM
    {
        public Location? Location { get; set; }

        public TravelPlan? TravelPlan { get; set; }
    }
}
