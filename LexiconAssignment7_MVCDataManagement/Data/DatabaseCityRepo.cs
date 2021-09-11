﻿using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class DatabaseCityRepo:ICityRepo
    {
        private readonly PeopleDbContext _db;
        public DatabaseCityRepo(PeopleDbContext peopleDbContext)
        {
            _db = peopleDbContext;
        }
        public City Create(CreateCityViewModel city)
        {
            City newCity = new City { Name = city.Name};
            _db.Cities.Add(newCity);
            _db.SaveChanges();

            return newCity;
        }

        public bool Delete(City city)
        {
            if (city != null)
            {
                var cityToDelete = _db.Cities
                    .Where<City>(x => x.ID == city.ID)
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
            var query = from city in _db.Cities
                        select city;

            return query.ToList<City>();
        }

        public City Read(int id)
        {
            City cityToRead = (from city in _db.Cities
                                   select city)
                        .FirstOrDefault(city => city.ID == id);

            return cityToRead;
        }

        public City Update(City city)
        {
            var query = from cityToUpdate in _db.Cities
                        where cityToUpdate.ID == city.ID
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