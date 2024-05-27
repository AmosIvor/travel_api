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

        public float LocationRateAverage { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
