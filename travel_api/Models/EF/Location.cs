using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_api.Models.EF
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime LocationOpenTime { get; set; }
        
        public decimal LocationLongtitude { get; set; }
        
        public decimal LocationLatitude { get; set; }

        public decimal LocationRateAverage { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
