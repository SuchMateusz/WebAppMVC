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
    public class TypeForListVM : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<TypeForListVM, Domain.Model.Type>().ReverseMap();
        }
    }

    public class NewTypeValidation : AbstractValidator<TypeForListVM>
    {
        public NewTypeValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(1, 50);
        }
    }
}