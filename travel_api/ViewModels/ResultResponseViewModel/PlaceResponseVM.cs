namespace travel_api.ViewModels.ResultResponseViewModel
{
    public class PlaceResponseVM
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime LocationOpenTime { get; set; }

        public decimal LocationLongtitude { get; set; }

        public decimal LocationLatitude { get; set; }

        public decimal LocationRateAverage { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string? CityDescription { get; set; }
    }
}
