namespace travel_api.ViewModels.EFViewModel
{
    public class UserVM
    {
        public string? Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? Male { get; set; }

        public DateTime? DateBirth { get; set; }

        public string? Avatar { get; set; }

        public ICollection<PostVM>? Posts { get; set; }

        public ICollection<FeedbackVM>? Feedbacks { get; set; }

        public ICollection<CommentVM>? Comments { get; set; }
    }
}
