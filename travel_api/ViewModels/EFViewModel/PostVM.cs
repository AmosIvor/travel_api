namespace travel_api.ViewModels.EFViewModel
{
    public class PostVM
    {
        public int PostId { get; set; }

        public DateTime PostDate { get; set; }

        public int PostTotalLike { get; set; }

        public string PostContent { get; set; }

        public string UserId { get; set; }
        public UserVM? User { get; set; }

        public int LocationId { get; set; }

        public LocationVM? Location { get; set; } 

        public ICollection<PostMediaVM>? PostMedias { get; set; }
        public ICollection<CommentVM>? Comments { get; set; }
    }
}
