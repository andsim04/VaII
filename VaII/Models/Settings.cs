using System.ComponentModel.DataAnnotations;

namespace VaII_Sem.Models
{
    public class Settings 
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }
        [Required, DataType(DataType.DateTime)]
        public string DateCreated { get; set; }
        public string? DateShot { get; set; }
        public string? Lens { get; set; }
        public int? FocalLength { get; set; }
        public double? Aperture { get; set; }
        public int? ShutterSpeed { get; set; }
        public string? ExposureMode { get; set; }
        public int? ISOSensitivity { get; set; }

        
    }
}
