using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.ViewModels.Requests.EFRequest
{
    public class MessageRequest
    {
        public int MessageId { get; set; }

        public string? Content { get; set; }

        public string? MessageType { get; set; }

        public DateTime? MessageCreateAt { get; set; } = DateTime.Now;

        public int RoomId { get; set; }

        public string? UserId { get; set; }

        public ICollection<MessageMediaBaseVM>? Files { get; set; }
    }
}
