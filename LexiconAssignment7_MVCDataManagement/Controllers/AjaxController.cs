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
        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
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
            if (_peopleService.FindBy(id) != null)
            {
                return PartialView("_PartialDetails", _peopleService.FindBy(id));
            }
            else
            {
                //ViewBag.Message = "Person was not found";
                //return PartialView("_PartialDelete", ViewBag.Message);
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
