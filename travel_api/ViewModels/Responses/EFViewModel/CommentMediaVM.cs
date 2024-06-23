namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class CommentMediaBaseVM
    {
        public int CommentMediaId { get; set; }

        public int CommentMediaOrder { get; set; }

        public string CommentMediaUrl { get; set; }

        public int CommentId { get; set; }
    }

    public class CommentMediaVM : CommentMediaBaseVM
    {
        public CommentBaseVM? Comment { get; set; }
    }
}
