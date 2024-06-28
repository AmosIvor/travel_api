namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class RoomDetailBaseVM
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string UserId { get; set; }
    }

    public class RoomDetailVM : RoomDetailBaseVM
    {
        public ChatRoomBaseVM? ChatRoom { get; set; }
    }
}
