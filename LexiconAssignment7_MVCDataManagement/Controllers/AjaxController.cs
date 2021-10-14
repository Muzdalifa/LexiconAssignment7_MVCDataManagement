using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Controllers
{
    [Authorize]
    public class AjaxController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        public AjaxController(IPeopleService peopleService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult People()
        {
            return PartialView("AjaxPeopleView", _peopleService.All().People);
        }

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindBy(id);
            if ( person != null)
            {
                //fill language name
                PersonLanguage[] personLanguages = person.PersonLanguages.ToArray();
                for (int i = 0; i < personLanguages.Length; i++)
                {
                    Language lg = _languageService.FindBy(personLanguages[i].LanguageId);
                    //person.PersonLanguages.Add(new PersonLanguage { PersonID = id, Person = person, LanguageID = lg.ID, Language = lg });
                    person.PersonLanguages[i].Language = lg;
                }

                return PartialView("_PartialDetails", person);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool result = _peopleService.Remove(id);
            if (result == true)
            {
                ViewBag.Message = $"Person with id = {id} has been deleted";
                return PartialView("_PartialDelete", ViewBag.Message);
            }
            else
            {
                ViewBag.Message = $"Error has been occur while attempt deleting a person with id = {id}";
                return PartialView("_PartialDelete", ViewBag.Message);
            }
        }

        public IActionResult Error()
        {
            ViewBag.Message = $"Person was not found!";
            return PartialView("_PartialDelete", ViewBag.Message);
        }
    }
}
