using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person>  People{ get; set; }

        private static int idCounter {
            set {
                idCounter = 0;
            }
            get {
                return idCounter;
            }
        }
        public Person Create(string name, string city, string phoneNumber)
        {
            Person newPerson =  new Person { ID = idCounter, Name = name, City = city, PhoneNumber = phoneNumber };
            idCounter++;
            return newPerson;
        }

        public List<Person> Read()
        {
            return People;
        }

        public Person Read(int id)
        {
            return People.FirstOrDefault(x => x.ID == id);
        }

        public Person Update(Person person)
        {
            int index = People.FindIndex(x => x.ID == person.ID);
            if(index != -1)
            {
                People[index] = person;
                return People[index];
            }
            else
            {
                throw new ArgumentNullException();
            }        
           
        }

        public bool Delete(Person person)
        {
            return People.Remove(person);
        }
    }
}
