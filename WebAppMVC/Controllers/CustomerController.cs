using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.Services;
using WebAppMVC.Application.ViewModel.Customer;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController (ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var model = _customerService.GetAllCustomerForList(3, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            searchString ??= String.Empty;
            var model = _customerService.GetAllCustomerForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(NewCustomerVM model)
        {
            int id = _customerService.AddCustomer(model);
            _logger.LogInformation("Dodano nowego użytkownika {id}", id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var customer = _customerService.GetCustomerForEdit(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(NewCustomerVM model)
        {
            _customerService.UpdateCustomer(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            _logger.LogInformation("Usunięto użytkownika o id: {id}", id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNewAddressForCustomer()
        {
            return View(new AddressForListVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewAddressForCustomer(AddressForListVM model)
        {
            _customerService.AddAddressModel(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAddressCustomerDetails()
        {
            var model = _customerService.GetAllAddressCustomer(10,1,0);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAddressCustomerDetails(int pageSize, int? pageNo, int customerId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            var model = _customerService.GetAllAddressCustomer(pageSize, pageNo.Value, customerId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditAddressCustDetails(int id)
        {
            var model = _customerService.GetAddressForEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditAddressCustDetails(AddressForListVM model)
        {
            _customerService.UpdateAddress(model); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCustomerContactInformaction()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomerContactInformaction(CustomerContactInformactionForListVm model)
        {
            _customerService.AddCustomerContactInformaction(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult GetAllContactCustoInf()
        {
            var model = _customerService.GetCustConDetails(3, 1, 0);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllContactCustoInf(int pageSize, int? pageNo, int searchInt)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            var model = _customerService.GetCustConDetails(pageSize, pageNo.Value, searchInt);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditCustContactDetails(int id)
        {
            var model = _customerService.GetCustContactForEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCustContactDetails(CustomerContactInformactionForListVm model)
        {
            _customerService.UpdateCustContact(model);
            return RedirectToAction("Index");
        }
    }
}