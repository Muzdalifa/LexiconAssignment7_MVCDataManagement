using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public interface ICityService
    {
        City Add(CreateCityViewModel person);
        CityViewModel All();
        CityViewModel FindBy(CityViewModel search);
        City FindBy(int id);
        City Edit(int id, City person);
        bool Remove(int id);
    }
}
