using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<City> Cities { get; set; }
    }
}
