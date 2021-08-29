using LexiconAssignment7_MVCDataManagement.Models;
using System.Collections.Generic;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel Person { get; set; }
        //public CreatePersonViewModel EditPerson { get; set; }
        //public int PersonId { get; set; }

        public List<Person> People = new List<Person>();

        public string Search { get; set; }

        public string DeleteError { get; set; }




    }
}