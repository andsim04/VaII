using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using VaII.Models;
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
        [ForeignKey("FK_Location")]
        public Guid? Location { get; set; }
        [ForeignKey("FK_Settings")]
        public Guid? Settings { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, MaxLength(300)]
        public string Description { get; set; }
        public string? Author { get; set; }
        [Required]
        public bool Published { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Last edit")]
        public DateTime Latest { get; set; } = DateTime.Now;  
        [DisplayName("Photo")]
        public byte[]? Content { get; set; }

        
    }

    
}
