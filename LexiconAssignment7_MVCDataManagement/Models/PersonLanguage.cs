using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class PersonLanguage
    {
        public int PersonLanguageId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
