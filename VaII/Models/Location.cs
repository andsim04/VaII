using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VaII.Models
{
    public class Location
    {
        [Key]
        public Guid ID { get; set; }

        [Required, MaxLength(30), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Country { get; set; }

        [Required, RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Place { get; set; }


    }
}
