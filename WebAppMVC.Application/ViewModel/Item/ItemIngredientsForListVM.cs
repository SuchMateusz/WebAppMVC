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
    public class ItemIngredientsForListVM : IMapFrom<ItemIngredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IngredientForListVM Ingredient { get; set; }

        public ItemForListVM Item { get; set; }

        public int ItemRef { get; set; }

        public int ItemIngredientsId { get; set; }

        public string NumberOfPiece { get; set; }

        public int NumberOfLiters { get; set; }

        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ItemIngredient, ItemIngredientsForListVM>()
                //.ForMember(x => x.Ingredient, opt => opt.MapFrom(s => s.Ingredients))
                //.ForMember(x => x.Item, opt => opt.MapFrom(s => s.Item))
                //.ForMember(x => x.ItemRef, opt => opt.MapFrom(s => s.ItemRef))
                //.ForMember(x => x.ItemIngredientsId, opt => opt.MapFrom(s => s.ItemIngredientsId))
                //.ForMember(x => x.NumberOfPiece, opt => opt.MapFrom(s => s.NumberOfPiece))
                //.ForMember(x => x.NumberOfLiters, opt => opt.MapFrom(s => NumberOfLiters))
                //.ForMember(x => x.Price, opt => opt.MapFrom(s => s.Price))
                .ReverseMap();
            //profile.CreateMap<Ingredient,IngredientForListVM>().ReverseMap();
            //profile.CreateMap<Domain.Model.Item,ItemForListVM>().ReverseMap();
        }
    }

    public class ItemIngredientsValidation : AbstractValidator<ItemIngredientsForListVM>
    {
        public ItemIngredientsValidation()
        {
            RuleFor(x => x.Ingredient).NotEmpty();
            RuleFor(x => x.Item).NotEmpty();
            RuleFor(x => x.ItemRef).NotNull();
        }
    }
}