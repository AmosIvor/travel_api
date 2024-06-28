namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class CommentBaseVM
    {
        public int CommentId { get; set; }

        public DateTime CommentDate { get; set; }

        public int CommentTotalLike { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }
    }

    public class CommentVM : CommentBaseVM
    {
        public UserBaseVM? User { get; set; }

        public PostBaseVM? Post { get; set; }

        public ICollection<CommentMediaBaseVM>? CommentMedias { get; set; }
    }
}
