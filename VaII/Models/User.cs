using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaII_Sem.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid ID { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Too long name :(")] 
        public string FirstName { get; set; }

        [Required,MaxLength(20, ErrorMessage = "Too long name :(")]
        public string LastName { get; set; }
        [Required, MinLength(5, ErrorMessage = "Jano :(")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Post>? Posts;
        [Required] 
        public string Role { get; set; }


    }
}
