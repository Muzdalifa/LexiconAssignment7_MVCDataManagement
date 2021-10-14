using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class DatabaseCityRepo:ICityRepo
    {
        private readonly PeopleDbContext _db;
        private readonly ICountryRepo _country;
        public DatabaseCityRepo(PeopleDbContext peopleDbContext, ICountryRepo country)
        {
            _db = peopleDbContext;
            _country = country;
        }
        public City Create(CreateCityViewModel city)
        {
            Country countryToAdd = _country.Read(city.CountryId);
            City newCity = new City { Name = city.Name, Country = countryToAdd};
            _db.Cities.Add(newCity);
            _db.SaveChanges();

            return newCity;
        }

        public bool Delete(City city)
        {
            if (city != null)
            {
                var cityToDelete = _db.Cities
                    .Where<City>(x => x.CityId == city.CityId)
                    .FirstOrDefault();

                if (cityToDelete != null)
                {
                    _db.Cities.Remove(cityToDelete);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<City> Read()
        {
            var query = (from city in _db.Cities
                        select city).Include(c => c.Country);

            return query.ToList<City>();
        }

        public City Read(int id)
        {
            City cityToRead = (from city in _db.Cities
                                   select city)
                        .FirstOrDefault(city => city.CityId == id);

            return cityToRead;
        }

        public City Update(City city)
        {
            var query = from cityToUpdate in _db.Cities
                        where cityToUpdate.CityId == city.CityId
                        select cityToUpdate;

            foreach (City data in query)
            {
                data.Name = city.Name;
            }
            _db.SaveChanges();
            return city;
        }
    }
}
