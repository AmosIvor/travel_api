namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class MessageMediaBaseVM
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int Order { get; set; }

        public string? URL { get; set; }
    }

    public class MessageMediaVM : MessageMediaBaseVM
    {

    }
}
