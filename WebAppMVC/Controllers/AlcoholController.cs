using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Item;
using Microsoft.AspNetCore.Authorization;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class AlcoholController : Controller
    {
        private readonly IAlcoholService _alcoholService;
        private readonly IIngredientsService _ingredientsService;
        private readonly IMarkAlcoholService _markAlcoService;
        private readonly ILogger<AlcoholController> _logger;

        public AlcoholController (IAlcoholService alcoholService, IIngredientsService ingredientsService, IMarkAlcoholService markAlcoholService,ILogger<AlcoholController> logger)
        {
            _alcoholService = alcoholService;
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
            int id = _alcoholService.AddAlcohol(newItemForListVM);
            if (id >0)
            {
                _logger.LogInformation("Create new Item success");
            }
            return RedirectToAction("GetAllAlcohols");
        }

        [HttpGet]
        public IActionResult GetAllAlcohols()
        {
            var model = _alcoholService.GetAllAlcohols(5, 1, "");
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
            var model = _alcoholService.GetAllAlcohols(paigeSize, paigeNo.Value, searchString);
            return View(model); 
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditAlcohol(int id)
        {
            var model = _alcoholService.GetAlcoholToEditItem(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditAlcohol(AlcoholForListVM item)
        {
                _alcoholService.UpdateAlcohol(item);
                return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteAlcohol(int id)
        {
            _alcoholService.DeleteAlcohol(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetAlcoholDetails(int id)
        {
            var model = _alcoholService.GetAlcoholDetails(id);
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
            var model = _alcoholService.GetAlcoholToEditItem(id);
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
        public IActionResult AddNewAlcoholIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAlcoholIngredient(AlcoholIngredientsForListVM model)
        {
            _alcoholService.AddAlcoholIngredients(model);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllAlcoholIngredientByItem()
        {
            var model = _alcoholService.GetAllAlcoholIngredientsByIdItem(5, 1, 2);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllAlcoholIngredientByItem(int pageSize, int? pageNo, int itemId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            var model = _alcoholService.GetAllAlcoholIngredientsByIdItem(pageSize, pageNo.Value, itemId);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditAlcoholIngredient(int id)
        {
            var model = _alcoholService.EditAlcoholIngredients(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditAlcoholIngredient(AlcoholIngredientsForListVM model)
        {
                _alcoholService.UpdateAlcoholIngredient(model);
                return RedirectToAction("Index");
        }

        public IActionResult DeleteAlcoholIngredient(int id)
        {
            _alcoholService.DeleteAlcoholIngredients(id);
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
            _alcoholService.AddNewCategory(model);
            return View();
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult DeleteCategory(int id) 
        { 
            _alcoholService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditCategory(int id)
        {
            var model = _alcoholService.EditCategory(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryForListVM model)
        {
                _alcoholService.UpdateCategory(model);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var model = _alcoholService.GetCategoryForListVM(10, 1, "");
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
            var model = _alcoholService.GetCategoryForListVM(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser, User")]
        public IActionResult AddNewDescription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewDescription(DescriptionForListVM description)
        {
            int id = _alcoholService.AddNewDescription(description);
            if (id > 0)
            {
                _logger.LogInformation("Create new Item success");
            }
            return RedirectToAction("GetAllAlcohols");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult EditDescription(int id)
        {
            var model = _alcoholService.GetAlcoholDescription(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDescription(DescriptionForListVM description)
        {
            _alcoholService.EditDescription(description);
            return RedirectToAction("Index");
        }
    }
}