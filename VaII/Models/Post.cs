using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
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
      
        [ForeignKey("FK_User")]
        public string? ApplicationUserFk { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public bool Published { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Last edit")]
        public DateTime Latest { get; set; } = DateTime.Now;  // po create alebo po uprave sa upravi lastest
        [DisplayName("Photo")]
        public byte[]? Content { get; set; }

        
    }

    
}
