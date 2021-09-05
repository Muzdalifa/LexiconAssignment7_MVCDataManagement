using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public interface ICityRepo
    {
        public City Create(CreateCityViewModel city);
        public List<City> Read();

        public City Read(int id);
        public City Update(City city);
        public bool Delete(City country);
    }
}
