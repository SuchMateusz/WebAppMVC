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
    public class AlcoholIngredientsForListVM : IMapFrom<AlcoholIngredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IngredientForListVM Ingredient { get; set; }

        public AlcoholForListVM Alcohol { get; set; }

        public int AlcoholRef { get; set; }

        public int IngredientId { get; set; }

        public string NumberOfPiece { get; set; }

        public decimal NumberOfLiters { get; set; }

        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AlcoholIngredient, AlcoholIngredientsForListVM>()
                .ReverseMap();
        }
    }

    public class AlcoholIngredientsValidation : AbstractValidator<AlcoholIngredientsForListVM>
    {
        public AlcoholIngredientsValidation()
        {
            RuleFor(x => x.Ingredient).NotEmpty();
            RuleFor(x => x.Alcohol).NotEmpty();
            RuleFor(x => x.AlcoholRef).NotEmpty().GreaterThan(0);
        }
    }
}