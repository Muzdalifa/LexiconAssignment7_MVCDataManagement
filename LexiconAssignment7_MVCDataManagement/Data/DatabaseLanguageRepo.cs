using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _db;
        public DatabaseLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _db = peopleDbContext;
        }
        public Language Create(CreateLanguageViewModel language)
        {
            Language newLanguage = new Language { Name = language.Name };
            _db.Languages.Add(newLanguage);
            _db.SaveChanges();

            return newLanguage;
        }

        public bool Delete(Language language)
        {
            if(language != null)
            {
                var languageToDelete = _db.Languages
                    .Where<Language>(x => x.ID == language.ID)
                    .FirstOrDefault();

                if(languageToDelete != null)
                {
                    _db.Languages.Remove(language);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Language> Read()
        {
            var query = (from language in _db.Languages
                        select language)
                        .Include(c => c.PersonLanguages);

            return query.ToList<Language>();
        }

        public Language Read(int id)
        {
            Language languageToRead = (from language in _db.Languages
                        select language)
                        .Include(c => c.PersonLanguages)
                        .FirstOrDefault(language => language.ID == id);
            return languageToRead;
        }

        public Language Update(Language language)
        {
            var query = from languageToUpdate in _db.Languages
                        where languageToUpdate.ID == language.ID
                        select languageToUpdate;

            foreach (Language data in query)
            {
                data.Name = language.Name;
            }

            _db.SaveChanges();
            return language;
        }
    }
}
