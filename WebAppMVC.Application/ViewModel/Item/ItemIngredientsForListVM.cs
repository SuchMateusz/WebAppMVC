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
        public IngredientForListVM Ingredient { get; set; }

        public ItemForListVM Item { get; set; }

        public int ItemRef { get; set; }

        public int ItemIngredientsId { get; set; }

        public string NumberOfPiece { get; set; }

        public int NumberOfLiters { get; set; }

        public void Mapper(Profile profile)
        {
            profile.CreateMap<ItemIngredient, ItemIngredientsForListVM>().ReverseMap();
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