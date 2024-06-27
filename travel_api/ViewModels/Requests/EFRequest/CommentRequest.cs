namespace travel_api.ViewModels.Requests.EFRequest
{
    public class CommentRequest
    {
        public int CommentId { get; set; }

        public DateTime CommentDate { get; set; }

        public int CommentTotalLike { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }
    }
}
