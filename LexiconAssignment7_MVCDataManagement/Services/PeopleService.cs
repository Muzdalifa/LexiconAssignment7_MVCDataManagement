using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepo _peopleRepo; /*= new InMemoryPeopleRepo();*/
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public Person Add(CreatePersonViewModel person)
        {
            CreatePersonViewModel newPerson = new CreatePersonViewModel { Name = person.Name, City = person.City, PhoneNumber = person.PhoneNumber };
            return _peopleRepo.Create(newPerson);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel { People = _peopleRepo.Read() };
            return peopleViewModel;
        }

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

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            PeopleViewModel searchedPeople = new PeopleViewModel();
            foreach (Person person in _peopleRepo.Read())
            {
                if (person.Name == search.Search.Name || person.City == search.Search.City || person.PhoneNumber == search.Search.PhoneNumber)
                {
                    searchedPeople.SearchedPeople.Add(person);
                }
            }
            return searchedPeople;
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
