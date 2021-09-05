using LexiconAssignment7_MVCDataManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CreateCityViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to fill out name field!")]
        [RegularExpression(@"[A-z]*", ErrorMessage = "Use only alphabets.")]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
