namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class PostBaseVM
    {
        public int PostId { get; set; }

        public DateTime PostDate { get; set; }

        public int PostTotalLike { get; set; }

        public string PostContent { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }
    }

    public class PostVM : PostBaseVM
    {
        public UserBaseVM? User { get; set; }

        public LocationBaseVM? Location { get; set; } 

        public ICollection<PostMediaBaseVM>? PostMedias { get; set; }

        public ICollection<CommentBaseVM>? Comments { get; set; }
    }
}
