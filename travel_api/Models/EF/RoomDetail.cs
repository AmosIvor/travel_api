using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("RoomDetail")]
    public class RoomDetail
    {
        [Key]
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string UserId { get; set; }
    }
}
