namespace travel_api.ViewModels.EFViewModel
{
    public class LocationVM
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime LocationOpenTime { get; set; }

        public decimal LocationLongtitude { get; set; }

        public decimal LocationLatitude { get; set; }

        public float LocationRateAverage { get; set; }

        public ICollection<PostVM>? Posts { get; set; }

        public ICollection<FeedbackVM>? Feedbacks { get; set; }
    }
}
