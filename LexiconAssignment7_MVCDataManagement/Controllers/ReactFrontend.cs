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
        IPeopleService _peopleService;
        //private readonly DatabasePeopleRepo _databasePeopleRepo;
        //private readonly ICityService _cityService;
        //private readonly ILanguageService _languageService;
        //private readonly IPersonLanguageRepo _personLanguageRepo;
        private readonly PeopleDbContext _db;


        //public ReactFrontendController(ICityService cityService, ILanguageService languageService,
        //    IPersonLanguageRepo personLanguageRepo, DatabasePeopleRepo databasePeopleRepo,
        public ReactFrontend(PeopleDbContext db, IPeopleService peopleService)
        {
            //_cityService = cityService;
            //_languageService = languageService;
            //_personLanguageRepo = personLanguageRepo;
            //_databasePeopleRepo = databasePeopleRepo;
            _db = db;
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_peopleService.All().People);
        }

        [HttpGet("{ReactFrontend}/{id}")]
        public IActionResult Get(int id)
        {
            //List<Person> people =  _databasePeopleRepo.Read();
            //Person person = _db.People.FirstOrDefault(x => x.ID == id);
            //return person;
            return new JsonResult(_peopleService.FindBy(1));
        }

        [HttpPost("{ReactFrontend}")]
        public ActionResult<Person> Post([FromBody]Person person)
        {
            //List<Person> people =  _databasePeopleRepo.Read();
            _db.People.Add(person);
            _db.SaveChanges();
            return Json(person);
        }
    }
}
