namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class ChatRoomVM
    {
        public int RoomId { get; set; }

        public string? RoomName { get; set; }

        public virtual ICollection<UserBaseVM>? Users { get; set; }
    }
}
