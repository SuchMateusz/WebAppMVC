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

            return View();
        }


    }
}