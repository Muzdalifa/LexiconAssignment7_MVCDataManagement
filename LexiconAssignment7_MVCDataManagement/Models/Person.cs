using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
