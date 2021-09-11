using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Add(CreateLanguageViewModel language)
        {
            return _languageRepo.Create(language);
        }

        public LanguageViewModel All()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel
            {
                Languages = _languageRepo.Read()
            };

            return languageViewModel;
        }

        public Language Edit(int id, Language language)
        {
            Language languageToUpdate = _languageRepo.Read(id);

            if(languageToUpdate != null)
            {
                return _languageRepo.Update(language);
            }
            else
            {
                return language;
            }
        }

        public LanguageViewModel FindBy(LanguageViewModel search)
        {
            search.Languages = _languageRepo.Read().FindAll(
                language => language.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                );
            return search;
        }

        public Language FindBy(int id)
        {
            return _languageRepo.Read(id);
        }

        public Language FindBy(string search)
        {
            return _languageRepo.FindBy(search);
        }

        public bool Remove(int id)
        {
            Language language = FindBy(id);
            return _languageRepo.Delete(language);
        }
    }
}
