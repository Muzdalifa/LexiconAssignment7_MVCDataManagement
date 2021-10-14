using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public PeopleController(IPeopleService peopleService, ICityService cityService, ILanguageService languageService, IPersonLanguageRepo personLanguageRepo)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _languageService = languageService;
            _personLanguageRepo = personLanguageRepo;
        }
        [AllowAnonymous]
        public IActionResult Start(PeopleViewModel peopleViewModel)
        {
            return View("Start");

        }
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            if (!string.IsNullOrEmpty(peopleViewModel.Search))
            {
                return View(_peopleService.FindBy(peopleViewModel));
            }
            else
            {
                return View(_peopleService.All());
            }
        }


        [HttpPost]
        public IActionResult Create(CreatePersonViewModel person) //name person here matter if you change it you get en error
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
            }
            return View("Index", _peopleService.All());
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string city, string phoneNumber, int[] languages)
        {
            City selectedCity = _cityService.FindBy(Convert.ToInt32(city));

            Person person = _peopleService.FindBy(id);
            person.Name = name;
            person.City = selectedCity;
            person.PhoneNumber = phoneNumber;
            person.PersonLanguages.Clear();

            for (int i = 0; i < languages.Length; i++)
            {
                Language lg = _languageService.FindBy(languages[i]);
                person.PersonLanguages.Add(new PersonLanguage { PersonId = id, Person = person, LanguageId = lg.LanguageId, Language = lg });
            }

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
