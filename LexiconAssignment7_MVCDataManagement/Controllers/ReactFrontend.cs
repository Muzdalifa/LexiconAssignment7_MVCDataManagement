using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ReactFrontend : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;
        private readonly ILanguageRepo _languageRepo;
        private readonly IPeopleRepo _peopleRepo;



        public ReactFrontend(PeopleDbContext db, IPeopleRepo peopleRepo,ICityRepo cityRepo, ICountryRepo countryRepo,ILanguageRepo languageRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
            _languageRepo = languageRepo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new { cities = _cityRepo.Read(), countries = _countryRepo.Read(), languages = _languageRepo.Read(), people = _peopleRepo.Read() };
            return Json(result);
        }

        [HttpPost]
        public ActionResult<Person> Post(CreatePersonViewModel person)
        {
            return (_peopleRepo.Create(person));
        }

        [HttpGet("{ReactFrontend}/{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_peopleService.FindBy(1));
        }


    }
}
