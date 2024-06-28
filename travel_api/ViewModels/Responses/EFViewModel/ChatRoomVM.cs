using travel_api.Models.EF;

namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class ChatRoomBaseVM
    {
        public int RoomId { get; set; }

        public string? RoomName { get; set; }
    }

    public class ChatRoomVM : ChatRoomBaseVM
    {
        public virtual ICollection<UserBaseVM>? Users { get; set; }

        public virtual ICollection<RoomDetail>? RoomDetails { get; set; }

        public virtual ICollection<Message>? Messages { get; set; }
    }
}
