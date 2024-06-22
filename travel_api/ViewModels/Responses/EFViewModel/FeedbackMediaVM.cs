namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class FeedbackMediaVM
    {
        public int FeedbackMediaId { get; set; }

        public int FeedbackMediaOrder { get; set; }

        public string FeedbackMediaUrl { get; set; }

        public int FeedbackId { get; set; }

        public FeedbackVM? Feedback { get; set; }
    }
}
