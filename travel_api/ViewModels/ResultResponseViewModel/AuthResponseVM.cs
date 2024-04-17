using travel_api.ViewModels.EFViewModel;

namespace travel_api.ViewModels.ResultResponseViewModel
{
    public class AuthResponseVM
    {
        public string? AccessToken { get; set; }

        public string? ExpiresAccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public string? ExpiresRefreshToken { get; set; }

        public UserVM? User { get; set; }
    }
}
