namespace travel_api.ViewModels.Requests.EFRequest
{
    public class PostRequest
    {
        public int PostId { get; set; }

        public DateTime PostDate { get; set; }

        public int PostTotalLike { get; set; }

        public string PostContent { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }
    }
}
