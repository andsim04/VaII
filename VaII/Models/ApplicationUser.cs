using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VaII_Sem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(20, ErrorMessage = "Too long name :("), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [PersonalData]
        public string FirstName { get; set; }

        [Required,MaxLength(20, ErrorMessage = "Too long name :("), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [PersonalData]
        public string LastName { get; set; }
        [Required, MinLength(5), MaxLength(10)]
        
        public override string UserName { get; set; }
      
     }
}
