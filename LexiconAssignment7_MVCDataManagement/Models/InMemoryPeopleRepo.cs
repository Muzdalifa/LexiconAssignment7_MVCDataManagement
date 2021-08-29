using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
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
        /// create person and add it to the People list
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
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
        /// Find all person from the list and return, if the list 
        /// </summary>
        /// <returns></returns>
        public List<Person> Read()
        {
            return People;
        }
        /// <summary>
        /// Find person by ID from People list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person Read(int id)
        {
            return People.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// find index of the person to update and update that index with new value
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
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
        /// remove person from the list
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool Delete(Person person)
        {
            return People.Remove(person);
        }
    }
}
