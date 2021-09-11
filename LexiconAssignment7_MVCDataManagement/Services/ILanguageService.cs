using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel language);
        LanguageViewModel All();
        LanguageViewModel FindBy(LanguageViewModel search);
        Language FindBy(int id);
        Language Edit(int id, Language language);
        bool Remove(int id);
        Language FindBy(string search);
    }
}
