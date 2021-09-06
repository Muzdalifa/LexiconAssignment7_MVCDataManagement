using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
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
        public DatabasePeopleRepo(PeopleDbContext peopleDbContext, ICityRepo cityRepo)
        {
            _db = peopleDbContext;
            _cityRepo = cityRepo;
        }
        public Person Create(CreatePersonViewModel person)
        {
            City selectedCity = _cityRepo.Read(Convert.ToInt32(person.City));

            Person newPerson = new Person { Name = person.Name, City =  selectedCity, PhoneNumber = person.PhoneNumber };            
            _db.People.Add(newPerson);
            _db.SaveChanges();

            return newPerson;
        }

        public bool Delete(Person person)
        {
            if (person != null)
            {
                var personToDelete = _db.People
                .Where<Person>(x => x.ID == person.ID)
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
            //without using linq
            //return  _db.People.ToList<Person>();

            //using linq
            var query = from person in _db.People
                        select person;

            return query.ToList<Person>();
        }

        public Person Read(int id)
        {
            //without using linq
            //return _db.People.ToList<Person>().FirstOrDefault<Person>(x => x.ID == id);

            //using linq
            Person personToRead = (from person in _db.People
                         select person)
                        .FirstOrDefault(person => person.ID == id); 
            
            return personToRead;
        }

        public Person Update(Person person)
        {
            var query = from personToUpdate in _db.People
                        where personToUpdate.ID == person.ID
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
