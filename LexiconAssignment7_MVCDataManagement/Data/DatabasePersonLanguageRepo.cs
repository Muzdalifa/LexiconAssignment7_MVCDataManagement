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
        public DatabasePersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _db = peopleDbContext;
        }
        public PersonLanguage Create(Person person, Language language)
        {
            PersonLanguage personLanguage = new PersonLanguage { Person = person, Language = language };
             _db.PersonLanguages.Add(personLanguage);
            _db.SaveChanges();

            return personLanguage;
        }

        public bool Delete(PersonLanguage language)
        {
            throw new NotImplementedException();
        }

        public List<PersonLanguage> Read()
        {
            var query = from personLanguage in _db.PersonLanguages
                        select personLanguage;

            return query.ToList<PersonLanguage>();
        }

        public PersonLanguage Read(int id)
        {
            var query = (from personLanguage in _db.PersonLanguages
                        select personLanguage)
                        .FirstOrDefault(x => x.PersonID == id);
            return query;
        }

        public PersonLanguage Update(PersonLanguage language)
        {
            throw new NotImplementedException();
        }
    }
}
