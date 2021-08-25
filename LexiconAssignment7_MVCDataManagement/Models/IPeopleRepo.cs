using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Models
{
    public interface IPeopleRepo
    {
        public Person Create(string name, string city, string phone);
        public List<Person> Read();

        public Person Read(int id);
        public Person Update(Person person);
        public bool Delete(Person person);
    }
}
