using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    /// <summary>
    /// Class to provide functionalities(services) to the controllers
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private IPeopleRepo _peopleRepo; 
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        /// <summary>
        /// Add person to the <paramref name="People"/> list of a <paramref name="InMemoryPeopleRepo"/> repository
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Object of type <paramref name="Person"/></returns>
        public Person Add(CreatePersonViewModel person)
        {
            return _peopleRepo.Create(person);
        }

        /// <summary>
        /// Read all people from <paramref name="People"/> list of a <paramref name="InMemoryPeopleRepo"/>
        /// </summary>
        /// <returns> Object of type <paramref name="PeopleViewModel"/></returns>
        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel { People = _peopleRepo.Read() };
            return peopleViewModel;
        }

        /// <summary>
        /// Edit person in a <paramref name="People"/> list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns>Object of type <paramref name="Person"/></returns>
        public Person Edit(int id, Person person)
        {
            Person personToUpdate = _peopleRepo.Read(id);

            if (person != null)

            {
                return _peopleRepo.Update(person);

            }
            else
            {
                return person;
            }
        }


        /// <summary>
        /// Find person by Id 
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Object of type <paramref name="PeopleViewModel"/></returns>
        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            search.People =  _peopleRepo.Read().FindAll(
                person=>person.Name.Contains(search.Search,System.StringComparison.OrdinalIgnoreCase) 
                || person.City.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase) 
                || person.PhoneNumber.Contains(search.Search)
            );

            return search;
        }

        /// <summary>
        /// Find <paramref name="Person"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of type <paramref name="Person"/></returns>
        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }


        /// <summary>
        /// Delete person from a <paramref name="People"/> list
        /// </summary>
        /// <param name="id"></param>
        /// <returns><paramref name="true"/></returns> if a Person has been deleted and <paramref name="false"/> if not
        public bool Remove(int id)
        {
            Person person = FindBy(id);
            return _peopleRepo.Delete(person);
        }
    }
}
