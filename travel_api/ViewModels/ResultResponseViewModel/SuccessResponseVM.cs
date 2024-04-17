namespace travel_api.ViewModels.ResultResponseViewModel
{
    public class SuccessResponseVM<T>
    {
        public string? Message { get; set; }

        public T? Data { get; set; }
    }
}
