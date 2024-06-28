using travel_api.Models.EF;

namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class TravelPlanBaseVM
    {
        public int TravelPlanId { get; set; }
        public string? TravelPlanName { get; set; }
        public DateTime PlanCreateAt { get; set; } = DateTime.Now;
        public DateTime TravelDate { get; set; } = DateTime.Now;
        public string? TravelDescription { get; set; }
        public string? TravelUrl { get; set; }
        public string? UserId { get; set; }
    }
    public class TravelPlanVM : TravelPlanBaseVM
    {
        public UserBaseVM? User { get; set; }
        public ICollection<PlanDetailBaseVM>? PlanDetails { get; set; }
    }
}
