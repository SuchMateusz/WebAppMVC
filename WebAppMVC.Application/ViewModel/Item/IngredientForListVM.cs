using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class IngredientForListVM : IMapFrom<WebAppMVC.Domain.Model.Ingredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Ingredient, IngredientForListVM>().ReverseMap();
        }
    }



}