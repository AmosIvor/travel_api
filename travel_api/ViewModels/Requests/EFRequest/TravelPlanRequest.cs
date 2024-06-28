namespace travel_api.ViewModels.Requests.EFRequest
{
    public class TravelPlanRequest
    {
        public int TravelPlanId { get; set; }
        public string? TravelPlanName { get; set; }
        public DateTime? PlanCreateAt { get; set; } = DateTime.Now;
        public DateTime? TravelDate { get; set; } = DateTime.Now;
        public string? TravelDescription { get; set; }
        public string? TravelUrl { get; set; }
        public string UserId { get; set; }
    }
}
