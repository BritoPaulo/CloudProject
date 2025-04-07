using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventease.Models
{
    public class EVENTS
    {
        [Key]
        public int EVENTS_ID { get; set; }

        [Required]
        public string EVENTS_NAME { get; set; }
        
        [Required]

        public DateTime EVENT_DATE { get; set; }

        public string DESCRIPTIONS { get; set; }

        [ForeignKey("VENUES")]
        public int? VENUES_ID { get; set; }
        public VENUES? VENUES { get; set; }


    }
}
