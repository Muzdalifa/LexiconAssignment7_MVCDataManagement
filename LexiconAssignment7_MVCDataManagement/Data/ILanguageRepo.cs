using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public interface ILanguageRepo
    {
        public Language Create(CreateLanguageViewModel language);
        public List<Language> Read();
        public Language Read(int id);
        public Language Update(Language language);
        public bool Delete(Language language);
    }
}
