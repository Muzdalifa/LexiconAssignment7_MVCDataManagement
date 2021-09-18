using LexiconAssignment7_MVCDataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CityViewModel
    {
        public CreateCityViewModel City { get; set; }

        public List<City> Cities = new List<City>();

        public CreateCityViewModel EditCity { get; set; }
        public string Search { get; set; }
    }
}
