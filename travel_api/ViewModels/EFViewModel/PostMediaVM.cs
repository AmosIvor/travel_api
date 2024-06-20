namespace travel_api.ViewModels.EFViewModel
{
    public class PostMediaVM
    {
        public int PostMediaId { get; set; }

        public int PostMediaOrder { get; set; }

        public string PostMediaUrl { get; set; }

        public int PostId { get; set; }

        public PostVM? Post { get; set; }
    }
}
