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

        public ActionResult Index()
        {
            return View();
        }
    }
}
