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
        public LocationBaseVM? Location { get; set; }

        public TravelPlanBaseVM? TravelPlan { get; set; }
    }

    public class PlanDetailWithLocationMediaVM : PlanDetailBaseVM
    {
        public LocationBaseVM? Location { get; set; }

        public ICollection<LocationMediaBaseVM>? LocationMedias { get; set;  }
    }
}
