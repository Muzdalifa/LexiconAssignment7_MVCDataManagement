using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;

        public PeopleController(IPeopleService peopleService, ICityService cityService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
        }

        public IActionResult Index(PeopleViewModel peopleViewModel)
        {

            if (!string.IsNullOrEmpty(peopleViewModel.Search))
            {
                return View(_peopleService.FindBy(peopleViewModel));
            }
            else
            {
                return View( _peopleService.All());
            }          
        }


        [HttpPost]
        public IActionResult Create(CreatePersonViewModel person) //name person here matter if you change it you get en error
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);             
            }
                return View("Index",_peopleService.All());          
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string city, string phoneNumber)
        {
            City selectedCity = _cityService.FindBy(Convert.ToInt32(city));
            Person person = new Person { ID = id, Name = name, City = selectedCity, PhoneNumber = phoneNumber };
            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, person);
            }

            return View("Index", _peopleService.All());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);
            
            return View("Index", _peopleService.All());
        }

    }
}
