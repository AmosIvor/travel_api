namespace travel_api.ViewModels.Responses.ResultResponseViewModel
{
    public class PlaceResponse<T>
    {
        public T Result { get; set; }
        public bool IsCity { get; set; }
        public bool IsLocation { get; set; }
    }
}
