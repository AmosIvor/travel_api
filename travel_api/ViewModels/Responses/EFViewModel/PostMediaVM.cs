namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class PostMediaBaseVM
    {
        public int PostMediaId { get; set; }

        public int PostMediaOrder { get; set; }

        public string PostMediaUrl { get; set; }

        public int PostId { get; set; }
    }

    public class PostMediaVM : PostMediaBaseVM
    {
        public PostBaseVM? Post { get; set; }
    }
}
