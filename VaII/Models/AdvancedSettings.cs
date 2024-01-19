using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VaII.Models
{
    public class AdvancedSettings
    {
        [Key]
        public Guid ID { get; set; }
        [DisplayName("Date shot"),DataType(DataType.Date)]
        public DateTime? DateShot { get; set; }
        public string? Aperture { get; set; }
        [DisplayName("Shutter speed")]
        public string? ShutterSpeed { get; set; }
        [DisplayName("ISO")]
        public int? ISOSensitivity { get; set; }
    }
}
