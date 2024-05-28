namespace travel_api.ViewModels.EFViewModel
{
    public class CommentVM
    {
        public int CommentId { get; set; }

        public string CommentDate { get; set; }

        public int CommentTotalLike { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }

        public ICollection<CommentMediaVM>? CommentMedias { get; set; }
    }
}
