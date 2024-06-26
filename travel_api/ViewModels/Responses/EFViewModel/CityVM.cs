namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class CityBaseVM
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public string? CityDescription { get; set; }

        public string? CityUrl { get; set; }
    }

    public class CityVM : CityBaseVM
    {
        public virtual ICollection<LocationBaseVM>? Locations { get; set; }

        public virtual ICollection<UserBaseVM>? Users { get; set; }
    }

    public class CityHasQuantityFeedbackVM : CityBaseVM
    {
        public int FeedbackQuantity { get; set; }
    }
}
