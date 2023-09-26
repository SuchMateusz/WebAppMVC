using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Application.ViewModel.Customer;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class NewItemForListVM : IMapFrom<WebAppMVC.Domain.Model.Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int YearProduction { get; set; }

        public float SugarContent { get; set; }

        public int Quantity { get; set; }

        public int ItemCategoryId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Item, NewItemForListVM>().ReverseMap();
        }
    }

    public class NewItemValidation : AbstractValidator<NewItemForListVM>
    {
        public NewItemValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3,30);
            RuleFor(x => x.TypeId).NotNull();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.YearProduction).NotNull();
            RuleFor(x => x.SugarContent).NotNull();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.ItemCategoryId).NotNull();
        }
    }
}