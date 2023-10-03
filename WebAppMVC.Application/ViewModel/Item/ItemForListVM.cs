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
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.TypeId, opt => opt.MapFrom(s => s.TypeId))
                .ForMember(x => x.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(x => x.YearProduction, opt => opt.MapFrom(s => s.YearProduction))
                .ForMember(x => x.SugarContent, opt => opt.MapFrom(s => SugarContent))
                .ForMember(x => x.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(x => x.ItemCategoryId, opt => opt.MapFrom(s => s.ItemCategoryId))
                .ReverseMap();
        }
    }

    public class ItemValidation : AbstractValidator<ItemForListVM>
    {
        public ItemValidation() 
        {
            RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.TypeId).NotEmpty();
        }
    }
}