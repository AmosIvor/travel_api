namespace travel_api.ViewModels.Requests.EFRequest
{
    public class FeedbackRequest
    {
        public int FeedbackId { get; set; }

        public DateTime FeedbackDate { get; set; }

        public string FeedbackContent { get; set; }

        public decimal FeedbackRate { get; set; }

        public int TripType { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }
    }
}
