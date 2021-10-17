using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _db;
        private readonly ICityRepo _cityRepo;
        private readonly ILanguageRepo _languageRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;
        public DatabasePeopleRepo(PeopleDbContext peopleDbContext, ICityRepo cityRepo, ILanguageRepo languageRepo, IPersonLanguageRepo personLanguageRepo)
        {
            _db = peopleDbContext;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
            _personLanguageRepo = personLanguageRepo;
        }
        public Person Create(CreatePersonViewModel person)
        {
            City selectedCity = _cityRepo.Read(Convert.ToInt32(person.City));

            Person newPerson = new Person { Name = person.Name, City =  selectedCity, PhoneNumber = person.PhoneNumber };            
            _db.People.Add(newPerson);
            _db.SaveChanges();

            for (int i = 0; i < person.Languages.Length; i++)
            {
                Language selectedLanguage = _languageRepo.Read(person.Languages[i]);
                _personLanguageRepo.Create(newPerson, selectedLanguage);
            }

            return newPerson;
        }

        public bool Delete(Person person)
        {
            if (person != null)
            {
                var personToDelete = _db.People
                .Where<Person>(x => x.PersonId == person.PersonId)
                .FirstOrDefault();
                if (personToDelete != null)
                {
                    _db.People.Remove(personToDelete);
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

        public List<Person> Read()
        {
            return  _db.People.Include(c => c.City).Include(c=>c.PersonLanguages).ToList<Person>();
            //return _db.People
            //    .Include(c => c.City)
            //    .ThenInclude(c => c.Country)
            //    .Include(c => c.PersonLanguages)
            //    .ThenInclude(l => l.Language)
            //    .ToList<Person>();
        }

        public Person Read(int id)
        {
            Person personToRead = (from person in _db.People
                                   select person)
                                   .Include(c => c.City)
                                   .Include(c => c.PersonLanguages)
                                   .FirstOrDefault(person => person.PersonId == id);

            return personToRead;
        }

        public Person Update(Person person)
        {
            var query = from personToUpdate in _db.People
                        where personToUpdate.PersonId == person.PersonId
                        select personToUpdate;

            foreach (Person data in query)
            {
                data.Name = person.Name;
                data.City = person.City;
                data.PhoneNumber = person.PhoneNumber;
            }
            _db.SaveChanges();

            return person;
        }
    }
}
