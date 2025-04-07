using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventease.Models
{
    public class BOOKINGS
    {
        [Key]
        public int BOOKINGS_ID { get; set; }

        [ForeignKey("EVENTS")]

        public int? EVENTS_ID { get; set; }
       public EVENTS? EVENTS { get; set; }

        [ForeignKey("VENUES")]
        public int? VENUES_ID { get; set; }
        public VENUES? VENUES { get; set; }
        public DateTime BOOKING_DATE { get; set; }
       
    }
}
