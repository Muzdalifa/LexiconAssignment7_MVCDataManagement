using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Country FindBy(int id);
        Country Edit(int id, Country person);
        bool Remove(int id);
    }
}
