using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.Services;
using WebAppMVC.Application.ViewModel.Customer;

namespace WebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController (ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _customerService.GetAllCustomerForList(2, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString == null)
            {
                searchString = String.Empty;
            }

            var model = _customerService.GetAllCustomerForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(NewCustomerVM model)
        {
            _customerService.AddCustomer(model);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewAddressForCustomer()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddNewAddressForCustomer(AddressForListVM model)
        //{
        //    var id = _customerService.AddAddressModel(model);
        //    return View(model);
        //}

        public IActionResult GetAddressCustomerDetails(int customerId)
        {
            var model = _customerService.GetAddressCustomerDetails(customerId);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomerContactInformaction()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddCustomerContactInformaction (ContactInformationModel model) 
        //{ 
        //    var id = _customerService.AddCustomerContactInformaction(model);
        //    return View(model);
        //}

        public IActionResult ViewCustomer(int custmerId)
        {
            var customerModel = _customerService.GetCustomerDetails(custmerId);
            return View(customerModel);
        }
    }
}