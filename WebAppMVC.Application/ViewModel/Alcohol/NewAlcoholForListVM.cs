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
    public class NewAlcoholForListVM : IMapFrom<WebAppMVC.Domain.Model.Alcohol>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int YearProduction { get; set; }

        public float SugarContent { get; set; }

        public int Quantity { get; set; }

        public int AlcoholCategoryId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Alcohol, NewAlcoholForListVM>().ReverseMap();
        }
    }

    public class NewAlcoholValidation : AbstractValidator<NewAlcoholForListVM>
    {
        public NewAlcoholValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).Length(3,30);
            RuleFor(x => x.TypeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.YearProduction).NotEmpty().GreaterThan(1000);
            RuleFor(x => x.SugarContent).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(x => x.AlcoholCategoryId).NotEmpty().GreaterThan(0);
        }
    }
}