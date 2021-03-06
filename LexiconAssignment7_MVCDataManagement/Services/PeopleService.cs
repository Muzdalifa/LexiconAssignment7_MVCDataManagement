using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepo _peopleRepo; 
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public Person Add(CreatePersonViewModel person)
        {
            return _peopleRepo.Create(person);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel { People = _peopleRepo.Read() };
            return peopleViewModel;
        }

        public Person Edit(int id, Person person)
        {
            Person personToUpdate = _peopleRepo.Read(id);

            if (personToUpdate != null)

            {
                return _peopleRepo.Update(person);

            }
            else
            {
                return person;
            }
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            search.People =  _peopleRepo.Read().FindAll(
                person=>person.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase) 
                || person.City.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase) 
                || person.PhoneNumber.Contains(search.Search)
            );

            return search;
        }

        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Person person = FindBy(id);
            return _peopleRepo.Delete(person);
        }
    }
}
