using LexiconAssignment7_MVCDataManagement.Models;
using System.Collections.Generic;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel Person { get; set; }
        public List<Person> People = new List<Person>();
        public List<Person> SearchedPeople = new List<Person>();

        public string Search { get; set; }




    }
}