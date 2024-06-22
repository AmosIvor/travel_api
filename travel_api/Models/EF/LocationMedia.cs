using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("LocationMedia")]
    public class LocationMedia
    {
        [Key]
        public int LocationMediaId { get; set; }

        public int LocationMediaOrder { get; set; }

        public string LocationMediaUrl { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}
