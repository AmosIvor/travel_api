namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class LocationMediaBaseVM
    {
        public int LocationMediaId { get; set; }

        public int LocationMediaOrder { get; set; }

        public string LocationMediaUrl { get; set; }

        public int LocationId { get; set; }
    }

    public class LocationMediaVM : LocationMediaBaseVM
    {
        public LocationBaseVM? Location { get; set; }
    }
}
