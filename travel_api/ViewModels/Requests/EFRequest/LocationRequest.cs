namespace travel_api.ViewModels.Requests.EFRequest
{
    public class LocationRequest
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime LocationOpenTime { get; set; }

        public decimal LocationLongtitude { get; set; }

        public decimal LocationLatitude { get; set; }

        public decimal? LocationRateAverage { get; set; }
    }
}
