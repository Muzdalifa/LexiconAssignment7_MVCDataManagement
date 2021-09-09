using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required(ErrorMessage = "You need to fill out name field!")]
        [RegularExpression(@"[A-zöåäÅÖÄ]*", ErrorMessage = "Use only alphabets.")]
        [MinLength(2), MaxLength(50)]
        public string Name { set; get; }
    }
}
