namespace travel_api.ViewModels.Requests.EFRequest
{
    public class ChatRequest
    {
    }

    public class ChatRoomRequest
    {
        public int RoomId { get; set; }

        public string? RoomName { get; set; }

        public List<string>? userIdsJoin { get; set; }

        public List<string>? userIdsLeave { get; set; }
    }
}
