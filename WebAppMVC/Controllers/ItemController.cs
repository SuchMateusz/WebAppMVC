using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using System.Diagnostics;
using WebAppMVC.Application.Interfaces;
using AutoMapper;
using WebAppMVC.Application.ViewModel.Item;


namespace WebAppMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController (IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
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
            _itemService.AddItem(newItemForListVM);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var model = _itemService.GetAllItems(5, 1, "");
            return View();
        }

        [HttpPost]
        public IActionResult GetAllItems(int paigeSize, int? paigeNo, string searchString) 
        { 
            if (!paigeNo.HasValue)
            {
                paigeNo = 1;
            }
            if (searchString == null)
            {
                searchString = string.Empty;
            }
            var model = _itemService.GetAllItems(paigeSize, paigeNo.Value, searchString);
            return View(model); 
        }

        [HttpGet]
        public IActionResult EditItem (int id)
        {
            var model = _itemService.GetItemToEditItem(id);
            return View(new ItemForListVM());
        }

        [HttpPost]
        public IActionResult EditItem(ItemForListVM item)
        {
            if(ModelState.IsValid)
            {
                _itemService.UpdateItem(item);
                return RedirectToAction("Index");
            }
            return View(item);
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

        public IActionResult GetIngredientDetails(int id)
        {
            var model = _itemService.GetIngredientDetails(id);
            return View(model);
        }

        public IActionResult GetTagsDetails(int id)
        {
            var model = _itemService.GetTagDetails(id);
            return View(model);
        }

        public IActionResult GetTypeDetails(int id)
        {
            var model = _itemService.GetTypeDetails(id);
            return View(model);
        }
    }
}