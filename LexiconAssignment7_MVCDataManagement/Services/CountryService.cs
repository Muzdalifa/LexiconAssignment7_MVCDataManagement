using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        /// <summary>
        /// Add Country to the <paramref name="Country"/> list of a <paramref name="InMemoryCountryRepo"/> repository
        /// </summary>
        /// <param name="Country"></param>
        /// <returns>Object of type <paramref name="Country"/></returns>
        public Country Add(CreateCountryViewModel country)
        {
            return _countryRepo.Create(country);
        }

        /// <summary>
        /// Read all Country from <paramref name="Country"/> list of a <paramref name="InMemoryCountryRepo"/>
        /// </summary>
        /// <returns> Object of type <paramref name="CountryViewModel"/></returns>
        public CountryViewModel All()
        {
            CountryViewModel CountryViewModel = new CountryViewModel { Countries = _countryRepo.Read() };
            return CountryViewModel;
        }

        /// <summary>
        /// Edit Country in a <paramref name="Country"/> list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Country"></param>
        /// <returns>Object of type <paramref name="Country"/></returns>
        public Country Edit(int id, Country country)
        {
            Country countryToUpdate = _countryRepo.Read(id);

            if (countryToUpdate != null)

            {
                return _countryRepo.Update(country);

            }
            else
            {
                return country;
            }
        }


        /// <summary>
        /// Find Country by Id 
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Object of type <paramref name="CountryViewModel"/></returns>


        public CountryViewModel FindBy(CountryViewModel search)
        {
            search.Countries = _countryRepo.Read().FindAll(
                country => country.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
            );

            return search;
        }

        /// <summary>
        /// Find <paramref name="Person"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of type <paramref name="Country"/></returns>
        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public CountryViewModel FindBy(PeopleViewModel search)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete Country from a <paramref name="Country"/> list
        /// </summary>
        /// <param name="id"></param>
        /// <returns><paramref name="true"/></returns> if a Country has been deleted and <paramref name="false"/> if not
        public bool Remove(int id)
        {
            Country country = FindBy(id);
            return _countryRepo.Delete(country);
        }
    }
}
