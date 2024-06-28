namespace travel_api.ViewModels.Requests.EFRequest
{
    public class PlanDetailRequest
    {
        public int PlanDetailId { get; set; }

        public string? PlanDetailDescription { get; set; }

        public int LocationId { get; set; }

        public int TravelPlanId { get; set; }
    }
}
