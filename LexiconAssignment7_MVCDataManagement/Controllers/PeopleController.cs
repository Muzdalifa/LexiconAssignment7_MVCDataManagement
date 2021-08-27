using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Controllers
{
    //problem kwenye controller
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public IActionResult Index()
        {            
            PeopleViewModel people = new PeopleViewModel();
            people = _peopleService.All();
            return View(people);
        }

        [HttpPost]
        public IActionResult Index(CreatePersonViewModel person) //name person here matter if you change it you get en error
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);             
            }
                return View(_peopleService.All());          
        }

        [HttpGet]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            return View(_peopleService.FindBy(peopleViewModel));
        }

        [HttpPut]
        public IActionResult Update(CreatePersonViewModel person)
        {

            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
            }
            return View(_peopleService.All());
        }
    }
}
