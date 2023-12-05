using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VaII_Sem.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required, MaxLength(20, ErrorMessage = "Too long name :(")] 
        public string FirstName { get; set; }

        [Required,MaxLength(20, ErrorMessage = "Too long name :(")]
        public string LastName { get; set; }
        [Required, MinLength(5, ErrorMessage = "Jano :(")]
        public string UserName { get; set; }
        

        public ICollection<Post>? Posts;
        


    }
}
