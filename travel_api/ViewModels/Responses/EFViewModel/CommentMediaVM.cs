namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class CommentMediaVM
    {
        public int CommentMediaId { get; set; }

        public int CommentMediaOrder { get; set; }

        public string CommentMediaUrl { get; set; }

        public int CommentId { get; set; }

        public CommentVM? Comment { get; set; }
    }
}
