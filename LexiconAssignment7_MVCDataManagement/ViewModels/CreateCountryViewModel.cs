using LexiconAssignment7_MVCDataManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CreateCountryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to fill out name field!")]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
