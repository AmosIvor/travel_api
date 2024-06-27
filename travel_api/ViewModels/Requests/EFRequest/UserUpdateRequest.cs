namespace travel_api.ViewModels.Requests.EFRequest
{
    public class UserUpdateRequest
    {
        public string UserId { get; set; }

        public int? CityId { get; set; }

        public string? UserDescription { get; set; }

        public string? Avatar { get; set; }
    }
}
