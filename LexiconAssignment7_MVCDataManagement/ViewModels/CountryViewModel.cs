using LexiconAssignment7_MVCDataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CountryViewModel
    {
        public CreateCountryViewModel Country { get; set; }

        public List<Country> People = new List<Country>();
        public string Search { get; set; }
    }
}
