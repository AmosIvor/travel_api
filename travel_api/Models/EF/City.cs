using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("City")]
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required, MaxLength(100)]
        public string CityName { get; set; }
    }
}
