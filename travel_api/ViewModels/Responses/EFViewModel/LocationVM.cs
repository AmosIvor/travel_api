using travel_api.ViewModels.Requests.EFRequest;

namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class LocationBaseVM
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime LocationOpenTime { get; set; }

        public decimal LocationLongtitude { get; set; }

        public decimal LocationLatitude { get; set; }

        public decimal LocationRateAverage { get; set; }
    }

    public class LocationVM : LocationBaseVM
    {
        public ICollection<PostBaseVM>? Posts { get; set; }

        public ICollection<FeedbackBaseVM>? Feedbacks { get; set; }

        public ICollection<LocationMediaBaseVM>? LocationMedias { get; set; }
    }
}
