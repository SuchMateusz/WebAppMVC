using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Model;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/alcohols/")]
    public class ListAlcoholController : ControllerBase
    {
        private readonly IAlcoholService _alcoholService;

        public ListAlcoholController(IAlcoholService alcoService)
        {
            _alcoholService = alcoService;
        }

        [HttpGet(Name = "GetListAlcohol")]
        public List<AlcoholForListVM> GetAlcohol()
        {
            var model = _alcoholService.GetAllAlcohols(Int32.MaxValue,1,"");
            var list = model.Alcohols.ToList();
            return list;
        }

        [HttpGet(Name = "GetAlcoholDetails")]
        public AlcoholForListVM GetALcoholDetails([FromBody] int id)
        {
            var model = _alcoholService.GetAlcoholDetails(id);
            return model;
        }

        [HttpGet(Name = "GetOfferAlcohols")]
        public List<Alcohol> GetOfferALcohols([FromBody] string name1, string name2, string name3)
        {
            var model = _alcoholService.GetAlcoholProposal(name1, name2, name3);
            return model;
        }
    }
}
