using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
