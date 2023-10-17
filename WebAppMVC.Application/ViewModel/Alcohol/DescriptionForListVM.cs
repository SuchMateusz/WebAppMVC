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
    public class DescriptionForListVM : IMapFrom<Domain.Model.AlcoholDescription>
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<DescriptionForListVM, Domain.Model.AlcoholDescription>().ReverseMap();
        }
    }

    public class NewDescriptionValidation : AbstractValidator<DescriptionForListVM>
    {
        public NewDescriptionValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(1, 100);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).Length(10, 1000);
        }
    }
}