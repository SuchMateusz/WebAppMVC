using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Infrastructure;

namespace WebAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        //public async Task<ActionResult> Index()
        //{
        //    List<User> users = await _userManager
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
