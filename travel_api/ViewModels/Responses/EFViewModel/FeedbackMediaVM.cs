namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class FeedbackMediaBaseVM
    {
        public int FeedbackMediaId { get; set; }

        public int FeedbackMediaOrder { get; set; }

        public string FeedbackMediaUrl { get; set; }

        public int FeedbackId { get; set; }
    }

    public class FeedbackMediaVM : FeedbackMediaBaseVM
    {
        public FeedbackBaseVM? Feedback { get; set; }
    }
}
