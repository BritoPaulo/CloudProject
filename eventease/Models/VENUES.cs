using System.ComponentModel.DataAnnotations;

namespace eventease.Models
{
    public class VENUES
    {
        [Key]
        public int VENUES_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string VENUES_NAME { get; set; }

        [Required]
        [StringLength(250)]
        public string LOCATIONS { get; set; }
        public int CAPACITY { get; set; }
        public string IMAGEURL { get; set; }
   
       
    
    }
}
