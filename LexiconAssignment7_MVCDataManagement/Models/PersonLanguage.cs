using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class PersonLanguage
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
