﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VaII_Sem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(20, ErrorMessage = "Too long name :("), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), MinLength(3)]
        [PersonalData]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required,MaxLength(20, ErrorMessage = "Too long name :("), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), MinLength(3)]
        [PersonalData]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [Required, MinLength(5), MaxLength(10)]
        [DisplayName("Username")]
        public override string UserName { get; set; }
      
     }
}
