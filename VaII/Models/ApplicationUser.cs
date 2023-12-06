using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VaII_Sem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(20, ErrorMessage = "Too long name :(")]
        [PersonalData]
        public string FirstName { get; set; }

        [Required,MaxLength(20, ErrorMessage = "Too long name :(")]
        [PersonalData]
        public string LastName { get; set; }
        [Required, MinLength(5, ErrorMessage = "Jano :(")]
        
        public override string UserName { get; set; }
        

        public ICollection<Post>? Posts;
     }
}
