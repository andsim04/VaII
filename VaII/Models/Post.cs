using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace VaII_Sem.Models
{
    public class Post
    {
        [Key] 
        public int ID { get; set; }
        [Key]
        [ForeignKey("FK_User")]
        public ApplicationUser ApplicationUserFk { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-hh:mm}", ApplyFormatInEditMode = true)]  
        public DateTime Latest { get; set; } = DateTime.Now;  // po create alebo po uprave sa upravi lastest
        [Required]
        public byte[]? Photo;
        [Required]
        public Image ThumImage;
        
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }

    
}
