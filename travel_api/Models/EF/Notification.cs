using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public string? NotiId { get; set; }
        public string? NotiTitle { get; set; }
        public string? NotiContent { get; set; }
        public DateTime CreateTime { get; set; }
        public string? Redirect { get; set; }
        public bool IsRead { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
