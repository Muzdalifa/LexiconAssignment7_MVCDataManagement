using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public class CityService:ICityService
    {
        private ICityRepo _cityRepo; 
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        /// <summary>
        /// Add City to the <paramref name="City"/> list of a <paramref name="InMemoryCityRepo"/> repository
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Object of type <paramref name="City"/></returns>
        public City Add(CreateCityViewModel city)
        {
            return _cityRepo.Create(city);
        }

        /// <summary>
        /// Read all City from <paramref name="City"/> list of a <paramref name="InMemoryCityRepo"/>
        /// </summary>
        /// <returns> Object of type <paramref name="CityViewModel"/></returns>
        public CityViewModel All()
        {
            CityViewModel cityViewModel = new CityViewModel { Cities = _cityRepo.Read() };
            return cityViewModel;
        }

        /// <summary>
        /// Edit City in a <paramref name="City"/> list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <returns>Object of type <paramref name="City"/></returns>
        public City Edit(int id, City city)
        {
            City cityToUpdate = _cityRepo.Read(id);

            if (cityToUpdate != null)

            {
                return _cityRepo.Update(city);

            }
            else
            {
                return city;
            }
        }


        /// <summary>
        /// Find City by Id 
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Object of type <paramref name="CityViewModel"/></returns>


        public CityViewModel FindBy(CityViewModel search)
        {
            search.Cities = _cityRepo.Read().FindAll(
                city => city.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
            );

            return search;
        }

        /// <summary>
        /// Find <paramref name="Person"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of type <paramref name="City"/></returns>
        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public CityViewModel FindBy(PeopleViewModel search)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete City from a <paramref name="City"/> list
        /// </summary>
        /// <param name="id"></param>
        /// <returns><paramref name="true"/></returns> if a City has been deleted and <paramref name="false"/> if not
        public bool Remove(int id)
        {
            City city = FindBy(id);
            return _cityRepo.Delete(city);
        }
    }
}
