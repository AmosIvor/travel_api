namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class FeedbackBaseVM
    {
        public int FeedbackId { get; set; }

        public DateTime FeedbackDate { get; set; }

        public string FeedbackContent { get; set; }

        public int FeedbackRate { get; set; }

        public int TripType { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }
    }

    public class FeedbackVM : FeedbackBaseVM
    {
        public UserBaseVM? User { get; set; }

        public LocationBaseVM? Location { get; set; }

        public ICollection<FeedbackMediaBaseVM>? FeedbackMedias { get; set; }

        //public Dictionary<int, int>? RatingStatistics { get; set; }
    }
}
