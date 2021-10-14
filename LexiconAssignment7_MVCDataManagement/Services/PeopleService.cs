using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    /// <summary>
    /// Class to provide functionalities(services) to the controllers
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;
        private readonly ILanguageRepo _languageRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;
        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo, ILanguageRepo languageRepo, IPersonLanguageRepo personLanguageRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
            _personLanguageRepo = personLanguageRepo;
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
            PeopleViewModel peopleViewModel = new PeopleViewModel {

                People = _peopleRepo.Read(),
                Cities = _cityRepo.Read(),
                Languages = _languageRepo.Read()
            };

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

            if (personToUpdate != null)

            {
                return _peopleRepo.Update(person);

            }
            else
            {
                return person;
            }
        }


        /// <summary>
        /// Find person by <paramref name="PeopleViewModel"/>
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Object of type <paramref name="PeopleViewModel"/></returns>
        public PeopleViewModel FindBy(PeopleViewModel search)
        {

            List<Language> searchedLanguage  = (from lang in _languageRepo.Read()
                                                where lang.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                                                select lang)
                                                .ToList<Language>();

            search.People = _peopleRepo.Read().FindAll(
                person => person.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                || person.City.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                || person.PersonLanguages.Exists(pl => searchedLanguage.Exists(sl => sl.LanguageId == pl.LanguageId))
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
