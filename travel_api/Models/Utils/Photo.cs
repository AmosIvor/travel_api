using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace travel_api.Models.Utils
{
    [Table("Photo")]
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Required]
        [MaxLength(200)]
        public string PhotoPublicId { get; set; }

        [Required]
        [MaxLength(200)]
        public string PhotoUrl { get; set; }
    }
}
