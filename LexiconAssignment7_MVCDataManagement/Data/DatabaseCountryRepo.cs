using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class DatabaseCountryRepo:ICountryRepo
    {
        private readonly PeopleDbContext _db;
        public DatabaseCountryRepo(PeopleDbContext PeopleDbContext)
        {
            _db = PeopleDbContext;
        }
        public Country Create(CreateCountryViewModel country)
        {
            Country newCountry = new Country { Name = country.Name };
            _db.Countries.Add(newCountry);
            _db.SaveChanges();

            return newCountry;
        }

        public bool Delete(Country Country)
        {
            if (Country != null)
            {
                var countryToDelete = _db.Countries
                .Where<Country>(x => x.CountryId == Country.CountryId)
                .FirstOrDefault();
                if (countryToDelete != null)
                {
                    _db.Countries.Remove(countryToDelete);
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

        public List<Country> Read()
        {
            var query = from country in _db.Countries
                        select country;

            return query.ToList<Country>();
        }

        public Country Read(int id)
        {
            Country countryToRead = (from country in _db.Countries
                                  select country)
                        .FirstOrDefault(country => country.CountryId == id);

            return countryToRead;
        }

        public Country Update(Country country)
        {
            var query = from countryToUpdate in _db.Countries
                        where countryToUpdate.CountryId == country.CountryId
                        select countryToUpdate;

            foreach (Country data in query)
            {
                data.Name = country.Name;
            }
            _db.SaveChanges();
            return country;
        }
    }
}
