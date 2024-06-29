namespace travel_api.ViewModels.Responses.UtilViewModel
{
    public class FeedbackBCVM
    {
        public int FeedbackId { get; set; }
        public string UserId { get; set; }
        public int LocationId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public string Medias { get; set; }
        public int TripType { get; set; }
    }
}
