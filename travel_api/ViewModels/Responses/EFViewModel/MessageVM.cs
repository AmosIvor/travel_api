﻿namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class MessageBaseVM
    {
        public int MessageId { get; set; }

        public string? Content { get; set; }
        
        public string? MessageType { get; set; }

        public int RoomId { get; set; }

        public string? UserId { get; set; }
    }

    public class MessageVM : MessageBaseVM
    {
        public ICollection<MessageMediaBaseVM>? Files { get; set; }

        public ChatRoomBaseVM? ChatRoom { get; set; }
        
        public UserBaseVM? User { get; set; }
    }
}
