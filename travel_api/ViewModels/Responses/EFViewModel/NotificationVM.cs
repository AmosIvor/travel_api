namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class NotificationVM
    {
        public string? NotiTitle { get; set; }
        public string? NotiContent { get; set; }
        public string? Redirect { get; set; }
        public List<string> UserIds { get; set; }
    }
}
