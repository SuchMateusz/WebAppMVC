using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class ItemForListVM : IMapFrom<WebAppMVC.Domain.Model.Item>
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int YearProduction { get; set; }

        public float SugarContent { get; set; }

        public int Quantity { get; set; }

        public int ItemCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ItemForListVM, WebAppMVC.Domain.Model.Item>()
                .ReverseMap();
        }
    }

    public class ItemValidation : AbstractValidator<ItemForListVM>
    {
        public ItemValidation() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
        }
    }
}