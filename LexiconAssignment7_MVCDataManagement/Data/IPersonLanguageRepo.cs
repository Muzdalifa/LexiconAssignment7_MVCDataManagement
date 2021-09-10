using LexiconAssignment7_MVCDataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public interface IPersonLanguageRepo
    {
        public PersonLanguage Create(Person person, Language language);
        public List<PersonLanguage> Read();
        public PersonLanguage Read(int id);
        public PersonLanguage Update(PersonLanguage language);
        public bool Delete(PersonLanguage language);
    }
}
