using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage = "You need to fill out name field!")]
        [RegularExpression(@"[A-zöåäÅÖÄ]*", ErrorMessage = "Use only alphabets.")]
        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You need to fill out name field!")]
        [RegularExpression(@"[A-zöåäÅÖÄ]*", ErrorMessage = "Use only alphabets.")]
        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please fill in your date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        
    }
}
