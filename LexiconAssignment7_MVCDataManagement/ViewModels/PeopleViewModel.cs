using LexiconAssignment7_MVCDataManagement.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel Person { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
        public List<City> Cities { get; set; } = new List<City>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<PersonLanguage> PersonLanguages { get; set; } = new List<PersonLanguage>();
        public CreatePersonViewModel EditPerson { get; set; }
        public string Search { get; set; }
    }
}