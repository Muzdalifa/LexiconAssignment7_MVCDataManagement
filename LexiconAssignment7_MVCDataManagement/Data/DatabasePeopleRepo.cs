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
        private readonly IPeopleRepo _peopleRepo;
        public DatabasePeopleRepo(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public Person Create(CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            throw new NotImplementedException();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
