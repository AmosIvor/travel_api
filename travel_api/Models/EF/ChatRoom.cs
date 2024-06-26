﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("ChatRoom")]
    public class ChatRoom
    {
        [Key]
        public int RoomId { get; set; }

        public string? RoomName { get; set; }

        public virtual ICollection<RoomDetail>? RoomDetails { get; set; }

        public virtual ICollection<Message>? Messages { get; set; }
    }
}
