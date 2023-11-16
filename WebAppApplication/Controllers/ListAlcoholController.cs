using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Item;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ListAlcoholController : ControllerBase
    {
        private readonly ILogger<ListAlcoholController> _logger;
        private readonly IAlcoholService _alcoholService;

        public ListAlcoholController(IAlcoholService alcoService, ILogger<ListAlcoholController> logger)
        {
            _logger = logger;
            _alcoholService = alcoService;
        }

        [HttpGet(Name = "GetListAlcohol")]
        public AlcoholForListVM GetALcohol(int id)
        {
            id = 1;
            var model = _alcoholService.GetAlcoholDetails(id);
            return model;
        }
    }
}
