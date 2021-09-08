using LexiconAssignment7_MVCDataManagement.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel Person { get; set; }

        public List<Person> People = new List<Person>();
        public List<City> Cities { get; set; } = new List<City>();        
        public CreatePersonViewModel EditPerson { get; set; }
        public string Search { get; set; }
        public string DeleteError { get; set; }

    }
}