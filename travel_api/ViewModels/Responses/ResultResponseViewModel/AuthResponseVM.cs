using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.ViewModels.Responses.ResultResponseViewModel
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
