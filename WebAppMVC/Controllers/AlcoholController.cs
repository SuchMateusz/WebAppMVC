using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using System.Diagnostics;
using WebAppMVC.Application.Interfaces;
using AutoMapper;
using WebAppMVC.Application.ViewModel.Item;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Authorization;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class AlcoholController : Controller
    {
        private readonly IAlcoholService _itemService;
        private readonly IIngredientsService _ingredientsService;
        private readonly IMarkAlcoholService _markAlcoService;
        private readonly ILogger<AlcoholController> _logger;

        public AlcoholController (IAlcoholService itemService, IIngredientsService ingredientsService, IMarkAlcoholService markAlcoholService,ILogger<AlcoholController> logger)
        {
            _itemService = itemService;
            _ingredientsService = ingredientsService;
            _markAlcoService = markAlcoholService;
            _logger = logger;
        }

        public IActionResult Index() 
        {

            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin, SuperUser, User")]
        public IActionResult AddNewAlcohol()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAlcohol(NewAlcoholForListVM newItemForListVM)
        {
            int id = _itemService.AddAlcohol(newItemForListVM);
            if (id >0)
            {
                _logger.LogInformation("Create new Item success");
            }
            return RedirectToAction("GetAllAlcohols");
        }

        [HttpGet]
        public IActionResult GetAllAlcohols()
        {
            var model = _itemService.GetAllAlcohols(5, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllAlcohols(int paigeSize, int? paigeNo, string searchString) 
        { 
            if (!paigeNo.HasValue)
            {
                paigeNo = 1;
            }

            searchString ??= string.Empty;
            var model = _itemService.GetAllAlcohols(paigeSize, paigeNo.Value, searchString);
            return View(model); 
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditAlcohol(int id)
        {
            var model = _itemService.GetAlcoholToEditItem(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditAlcohol(AlcoholForListVM item)
        {
                _itemService.UpdateAlcohol(item);
                return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteAlcohol(int id)
        {
            _itemService.DeleteAlcohol(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetAlcoholDetails(int id)
        {
            var model = _itemService.GetAlcoholDetails(id);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult AddNewIngredients()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult AddNewIngredients(IngredientForListVM ingredientForListVM)
        {

            _ingredientsService.AddNewIngredient(ingredientForListVM);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult GetAllIngredients()
        {
            var model = _ingredientsService.GetAllIngredient(10, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllIngredients(int pageSize, int? pageNo, string searchString)
        {
            searchString ??= String.Empty;

            if (!pageNo.HasValue)
            {
                pageNo = 0;
            }
            var model = _ingredientsService.GetAllIngredient(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult IngredientToEdit(int id)
        {
            var model = _itemService.GetAlcoholToEditItem(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult IngredientToEdit(IngredientForListVM model)
        {
            _ingredientsService.UpdateIngredient(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteIngredients(int id)
        {
            _ingredientsService.DeleteIngredient(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult AddNewtag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewTag(TagForListVM model)
        {
            _markAlcoService.AddTag(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            var model = _markAlcoService.GetAllTags(10, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllTags(int pageSize, int? pageNo, string searchstring)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            searchstring ??= string.Empty;
            var model = _markAlcoService.GetAllTags(pageSize, pageNo.Value, searchstring);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditTag(int id)
        {
            var model = _markAlcoService.GetTagToEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditTag(TagForListVM model)
        {
            _markAlcoService.UpdateTag(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteTag(int id)
        {
            _markAlcoService.DeleteTag(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult AddNewType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewType(TypeForListVM model)
        {
            _markAlcoService.AddType(model);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllType()
        {
            var model = _markAlcoService.GetAllType(10, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllType(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            searchString ??= string.Empty;

            var model = _markAlcoService.GetAllType(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditType(int id)
        {
            var model = _markAlcoService.GetTypeToEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditType(TypeForListVM model)
        {
            _markAlcoService.UpdateType(model);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteType(int id)
        {
            _markAlcoService.DeleteType(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult AddNewItemIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAlcoholIngredient(AlcoholIngredientsForListVM model)
        {
            _itemService.AddAlcoholIngredients(model);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllAlcoholIngredientByItem()
        {
            var model = _itemService.GetAllAlcoholIngredientsByIdItem(5, 1, 2);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllAlcoholIngredientByItem(int pageSize, int? pageNo, int itemId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            var model = _itemService.GetAllAlcoholIngredientsByIdItem(pageSize, pageNo.Value, itemId);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditAlcoholIngredient(int id)
        {
            var model = _itemService.EditAlcoholIngredients(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditAlcoholIngredient(AlcoholIngredientsForListVM model)
        {
                _itemService.UpdateAlcoholIngredient(model);
                return RedirectToAction("Index");
        }

        public IActionResult DeleteAlcoholIngredient(int id)
        {
            _itemService.DeleteAlcoholIngredients(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(CategoryForListVM model)
        {
            _itemService.AddNewCategory(model);
            return View();
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteCategory(int id) 
        { 
            _itemService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditCategory(int id)
        {
            var model = _itemService.EditCategory(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryForListVM model)
        {
                _itemService.UpdateCategory(model);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var model = _itemService.GetCategoryForListVM(10, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllCategory(int pageSize, int? pageNo, string searchString) 
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            searchString ??= string.Empty;
            var model = _itemService.GetCategoryForListVM(pageSize, pageNo.Value, searchString);
            return View(model);
        }
    }
}