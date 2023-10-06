using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using System.Diagnostics;
using WebAppMVC.Application.Interfaces;
using AutoMapper;
using WebAppMVC.Application.ViewModel.Item;
using System.Drawing.Printing;


namespace WebAppMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController (IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        public IActionResult Index() 
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddNewItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewItem(NewItemForListVM newItemForListVM)
        {
            int id = _itemService.AddItem(newItemForListVM);
            if (id >0)
            {
                _logger.LogInformation("Create new Item success");
            }
            return RedirectToAction("GetAllItems");
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var model = _itemService.GetAllItems(5, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllItems(int paigeSize, int? paigeNo, string searchString) 
        { 
            if (!paigeNo.HasValue)
            {
                paigeNo = 1;
            }

            searchString ??= string.Empty;
            var model = _itemService.GetAllItems(paigeSize, paigeNo.Value, searchString);
            return View(model); 
        }

        [HttpGet]
        public IActionResult EditItem (int id)
        {
            var model = _itemService.GetItemToEditItem(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditItem(ItemForListVM item)
        {
                _itemService.UpdateItem(item);
                return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int id)
        {
            _itemService.DeleteItem(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetItemDetails(int id)
        {
            var model = _itemService.GetItemDetails(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewIngredients()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewIngredients(IngredientForListVM ingredientForListVM)
        {
                _itemService.AddNewIngredient(ingredientForListVM);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllIngredients()
        {
            var model = _itemService.GetAllIngredient(10, 1, "");
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
            var model = _itemService.GetAllIngredient(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult IngredientToEdit(int id)
        {
            var model = _itemService.GetItemToEditItem(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult IngredientToEdit(IngredientForListVM model)
        {
            _itemService.UpdateIngredient(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteIngredients(int id)
        {
            _itemService.DeleteIngredient(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNewtag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewTag(TagForListVM model)
        {
            int id = _itemService.AddTag(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            var model = _itemService.GetAllTags(10, 1, "");
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
            var model = _itemService.GetAllTags(pageSize, pageNo.Value, searchstring);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditTag(int id)
        {
            var model = _itemService.GetTagToEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditTag(TagForListVM model)
        {
                _itemService.UpdateTag(model);
                return RedirectToAction("Index");
        }

        public IActionResult DeleteTag(int id)
        {
            _itemService.DeleteTag(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNewType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewType(TypeForListVM model)
        {
            var id = _itemService.AddType(model);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllType()
        {
            var model = _itemService.GetAllType(10, 1, "");
            return View();
        }

        [HttpPost]
        public IActionResult GetAllType(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            searchString ??= string.Empty;

            var model = _itemService.GetAllType(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditType(int id)
        {
            var model = _itemService.GetTypeToEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditType(TypeForListVM model)
        {
            _itemService.UpdateType(model);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteType(int id)
        {
            _itemService.DeleteType(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult AddNewItemIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewItemIngredient(ItemIngredientsForListVM model)
        {
            int id = _itemService.AddItemIngredients(model);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllItemIngredientByItem()
        {
            var model = _itemService.GetAllItemIngredientsByIdItem(5, 1, 2);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllItemIngredientByItem(int pageSize, int? pageNo, int itemId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            var model = _itemService.GetAllItemIngredientsByIdItem(pageSize, pageNo.Value, itemId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditItemIngredient(int id)
        {
            var model = _itemService.EditItemIngredients(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditItemIngredient(ItemIngredientsForListVM model)
        {
                _itemService.UpdateItemIngredient(model);
                return RedirectToAction("Index");
        }

        public IActionResult DeleteItemIngredient(int id)
        {
            _itemService.DeleteItemIngredients(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(CategoryForListVM model)
        {
            int id = _itemService.AddNewCategory(model);
            return View();
        }

        public IActionResult DeleteCategory(int id) 
        { 
            _itemService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
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