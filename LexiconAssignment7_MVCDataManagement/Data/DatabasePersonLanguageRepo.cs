using LexiconAssignment7_MVCDataManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class DatabasePersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _db;
        private readonly ILanguageRepo _languageRepo;
        //private readonly IPersonLanguageRepo _personLanguageRepo;
        public DatabasePersonLanguageRepo(PeopleDbContext peopleDbContext, ILanguageRepo languageRepo)
        {
            _db = peopleDbContext;
            _languageRepo = languageRepo;
        }
        public PersonLanguage Create(Person person, Language language)
        {
            PersonLanguage personLanguage = new PersonLanguage { Person = person, Language = language };
             _db.PersonLanguages.Add(personLanguage);
            _db.SaveChanges();

            return personLanguage;
        }

        public bool Delete(PersonLanguage personLanguage)
        {
            if(personLanguage != null)
            {
                PersonLanguage personLgToDelete = (from personlg in _db.PersonLanguages
                            where (personlg.LanguageId == personLanguage.LanguageId && personlg.PersonId == personLanguage.PersonId)
                            select personlg)
                            .FirstOrDefault();
                if(personLgToDelete != null)
                {
                    _db.PersonLanguages.Remove(personLgToDelete); 
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

        public List<PersonLanguage> Read()
        {
            var query = (from personLanguage in _db.PersonLanguages
                        select personLanguage)
                        .Include(c => c.Language)
                        .Include(c => c.Person);

            return query.ToList<PersonLanguage>();
        }

        public PersonLanguage Read(int id)
        {
            var query = (from personLanguage in _db.PersonLanguages
                        select personLanguage)
                        .Include(c => c.Language)
                        .Include(c => c.Person)
                        .FirstOrDefault(x => x.PersonId == id);
            return query;
        }

        public List<PersonLanguage> Update(int[] languages, Person person)
        {
            
            for (int i = 0; i < languages.Length; i++)
            {
                Language selectedLanguage = _languageRepo.Read(languages[i]);

                Create(person, selectedLanguage);
                _db.PersonLanguages.Add(new PersonLanguage { Language = selectedLanguage, Person = person});
            }

            _db.SaveChanges();

            return person.PersonLanguages;






            ////var query = from personlg in _db.PersonLanguages
            ////            where personlg.PersonID == personLanguage.PersonID
            ////            select personlg;
            ////if(query != null)
            ////{
            ////    foreach (var item in query)
            ////    {
            //        Language language = _languageRepo.Read(personLanguage.LanguageID);                                        

            //        _db.PersonLanguages.Add(new PersonLanguage{ Language = language, Person = personLanguage.Person});
            //        _db.SaveChanges();
            ////    }            
            ////}
            //return personLanguage;
        }
    }
}
