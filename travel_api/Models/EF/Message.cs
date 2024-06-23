using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string? Content { get; set; }

        public string? MessageType { get; set; }

        public int RoomId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("RoomId")]
        public virtual ChatRoom? Room { get; set; }

        public virtual ICollection<MessageMedia>? MessageMedias { get; set; }
    }
}
