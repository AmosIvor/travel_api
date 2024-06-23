using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("MessageMedia")]
    public class MessageMedia
    {
        [Key]
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int Order { get; set; }

        public string URL { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
    }
}
