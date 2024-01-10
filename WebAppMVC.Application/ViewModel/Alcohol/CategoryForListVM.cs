using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class CategoryForListVM : IMapFrom<Domain.Model.AlcoholCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryForListVM, AlcoholCategory>().ReverseMap();
        }
    }

    public class NewCategoryValidation : AbstractValidator<CategoryForListVM>
    {
        public NewCategoryValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(3, 100);
        }
    }
}