using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
