using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public interface ICountryRepo
    {
        public Country Create(CreateCountryViewModel country);
        public List<Country> Read();
        public Country Read(int id);
        public Country Update(Country country);
        public bool Delete(Country country);
    }
}
