namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class FeedbackVM
    {
        public int FeedbackId { get; set; }

        public DateTime FeedbackDate { get; set; }

        public string FeedbackContent { get; set; }

        public decimal FeedbackRate { get; set; }

        public int TripType { get; set; }

        public string UserId { get; set; }

        public UserVM User { get; set; }

        public int LocationId { get; set; }

        public LocationVM? Location { get; set; }

        public ICollection<FeedbackMediaVM>? FeedbackMedias { get; set; }
    }
}
