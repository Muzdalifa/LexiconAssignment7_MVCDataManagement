using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class Language
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
