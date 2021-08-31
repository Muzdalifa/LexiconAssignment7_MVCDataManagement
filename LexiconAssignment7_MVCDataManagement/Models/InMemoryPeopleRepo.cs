using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    /// <summary>
    /// Mock repository to manage <paramref name="Person"/> class's data 
    /// </summary>
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> People = new List<Person>();

        private static int idCounter = 0;
        public int IdCounter
        {
            get
            {
                return idCounter;
            }
            private set
            {
                idCounter++;
            }
        }

        /// <summary>
        /// Create person and add it to the <paramref name="People"/> list
        /// </summary>
        /// <param name="person">Object of type <paramref name="CreatePersonViewModel"/> </param>
        /// <returns>Object of type <paramref name="Person"/></returns>
        public Person Create(CreatePersonViewModel person)
        {
            idCounter++;
            Person newPerson =  new Person { 
                ID = IdCounter,
                Name = person.Name,
                City = person.City,
                PhoneNumber = person.PhoneNumber 
            };       
      
            People.Add(newPerson);

            return newPerson;
        }

        /// <summary>
        /// Return all person from <paramref name="People"/> list
        /// </summary>
        /// <returns>List of type <paramref name="Person"/></returns>
        public List<Person> Read()
        {
            return People;
        }

        /// <summary>
        /// Find person by ID from People list
        /// </summary>
        /// <param name="id">Id of a person</param>
        /// <returns>Object of type <paramref name="Person"/></returns>
        public Person Read(int id)
        {
            return People.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// Update given person in the <paramref name="People"/> list
        /// </summary>
        /// <param name="person"></param>
        ///<exception cref="ArgumentNullException"></exception>
        /// When <paramref name="person.ID"/> is not found 
        /// <returns>Object of type <paramref name="Person"/></returns>
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

        /// <summary>
        /// Remove person from the <paramref name="People"/> list
        /// </summary>
        /// <param name="person"></param>
        /// <returns><paramref name="true"/> if Person has been deleted and <paramref name="false"/> if not</returns>
        public bool Delete(Person person)
        {
            return People.Remove(person);
        }
    }
}
