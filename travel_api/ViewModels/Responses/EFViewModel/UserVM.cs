namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class UserBaseVM
    {
        public string? Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? Male { get; set; }

        public DateTime? DateBirth { get; set; }

        public string? Avatar { get; set; }

        public string? UserDescription { get; set; }

        public int CityId { get; set; }
    }

    public class UserVM : UserBaseVM
    {
        public ICollection<PostBaseVM>? Posts { get; set; }

        public ICollection<FeedbackBaseVM>? Feedbacks { get; set; }

        public ICollection<CommentBaseVM>? Comments { get; set; }

        public CityBaseVM? City { get; set; }
    }
}
