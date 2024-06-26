﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Alcohol;
using WebAppMVC.Application.ViewModel.Item;

namespace WebAppMVC.Controllers
{
    public class AlcoholHelperController : Controller
    {
        private readonly IAlcoholService _alcoholService;
        private readonly ILogger<AlcoholController> _logger;

        public AlcoholHelperController(IAlcoholService alcoholService,  ILogger<AlcoholController> logger)
        {
            _alcoholService = alcoholService;

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser, User")]
        public IActionResult GetProposalAlcohol()
        {
            var model = _alcoholService.GetAlcoholProposal("", "", "");
            var listToShow = _alcoholService.GetAlcoholProposalViewModel(model);
            return View(listToShow);
        }

        [HttpPost]
        public IActionResult GetProposalAlcohol(string ingredient1, string ingredient2, string ingredient3)
        {
            ingredient1 ??= String.Empty;
            ingredient2 ??= String.Empty;
            ingredient3 ??= String.Empty;
            var model = _alcoholService.GetAlcoholProposal(ingredient1, ingredient2, ingredient3);
            var listToShow = _alcoholService.GetAlcoholProposalViewModel(model);
            return View(listToShow);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser, User")]
        public IActionResult HelpCreateNewWine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HelpCreateNewWine(int addedSugar, int litersOfWine, int power)
        {
            var sugar = _alcoholService.SuggarForNewWine(addedSugar, litersOfWine, power);
            return View(sugar);
        }
    }
}
