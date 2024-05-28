namespace travel_api.ViewModels.EFViewModel
{
    public class FeedbackVM
    {
        public int FeedbackId { get; set; }

        public DateTime FeedbackDate { get; set; }

        public string FeedbackContent { get; set; }

        public float FeedbackRate { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }

        public LocationVM? Location { get; set; }

        public ICollection<FeedbackMediaVM>? FeedbackMedias { get; set; }
    }
}
