namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class CityBaseVM
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public string? CityDescription { get; set; }
    }

    public class CityVM : CityBaseVM
    {

    }
}
