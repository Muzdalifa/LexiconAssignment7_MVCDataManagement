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
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            PeopleViewModel people = new PeopleViewModel();

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
        //create person
        public IActionResult Index(CreatePersonViewModel person) //name person here matter if you change it you get en error
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);             
            }
                return View(_peopleService.All());          
        }

        //[HttpPut]
        //[Route("/Index/id")]
        //public IActionResult Index(PeopleViewModel id, CreatePersonViewModel person)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        _peopleService.Edit(id.PersonId, new Person { Name = person.Name, City = person.City, PhoneNumber = person.PhoneNumber });  
        //    }
        //    return View(_peopleService.All());
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);
            
            return View("Index", _peopleService.All());
        }

    }
}
