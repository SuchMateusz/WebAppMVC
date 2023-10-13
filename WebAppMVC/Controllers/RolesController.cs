using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class RolesController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
