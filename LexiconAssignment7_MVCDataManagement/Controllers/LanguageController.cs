using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using LexiconAssignment7_MVCDataManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Controllers
{
    [Authorize]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public IActionResult Index(LanguageViewModel languageViewModel)
        {
            if (!string.IsNullOrEmpty(languageViewModel.Search))
            {
                return View(_languageService.FindBy(languageViewModel));
            }
            else
            {
                return View(_languageService.All());
            }
        }

        [HttpPost]
        public IActionResult Create(CreateLanguageViewModel language)
        {
            if (ModelState.IsValid)
            {
                _languageService.Add(language);
            }

            return View("Index", _languageService.All());
        }

        [HttpPost]
        public IActionResult Edit(int id, Language language)
        {
            if (ModelState.IsValid)
            {
                _languageService.Edit(id, language);
            }

            return View("Index", _languageService.All());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _languageService.Remove(id);
            return View("Index", _languageService.All());
        }

    }
}
