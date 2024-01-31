using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;
using Bogus;
using WebAppMVC.Application.ViewModel.Item;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Bogus.DataSets;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class ProductGeneratorHelper
    {
        public AlcoholForListVM AlcoholGenerator()
        {
            var alcohol = new Faker<AlcoholForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10))
                .RuleFor(a => a.TypeId, f => f.Random.Int(1, 1))
                .RuleFor(a => a.Price, f => f.Random.Decimal(1, 50))
                .RuleFor(a => a.YearProduction, f => f.Random.Int(1980, 2024))
                .RuleFor(a => a.SugarContent, f => f.Random.Float(0, 30))
                .RuleFor(a => a.Quantity, f => f.Random.Int(1, 50))
                .RuleFor(a => a.AlcoholCategoryId, f => f.Random.Int(1, 1))
                ;

            var model = alcohol.Generate();
            return model;
        }
        
        public NewAlcoholForListVM NewAlcoholGenerator()
        {
            var alcohol = new Faker<NewAlcoholForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10))
                .RuleFor(a => a.TypeId, f => f.Random.Int(1, 1))
                .RuleFor(a => a.Price, f => f.Random.Decimal(1, 50))
                .RuleFor(a => a.YearProduction, f => f.Random.Int(1980, 2024))
                .RuleFor(a => a.SugarContent, f => f.Random.Float(0, 30))
                .RuleFor(a => a.Quantity, f => f.Random.Int(1, 50))
                .RuleFor(a => a.AlcoholCategoryId, f => f.Random.Int(1, 1))
                ;

            var model = alcohol.Generate();
            return model;
        }

        public AlcoholIngredientsForListVM NewAlcoholIngredientGenerator()
        {
            var alcohol = new Faker<AlcoholIngredientsForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10))
                .RuleFor(a => a.AlcoholRef, f => f.Random.Int(1, 1))
                ;

            var model = alcohol.Generate();
            model.Ingredient = IngredientGenerator();
            model.Item = AlcoholGenerator();
            return model;
        }

        public DescriptionForListVM DescriptionGenerator()
        {
            var desc = new Faker<DescriptionForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10))
                .RuleFor(o => o.Description, f => f.Random.Words(10))
                ;
                
            var model = desc.Generate();
            return model;
        }
        public CategoryForListVM CategoryGenerator()
        {
            var category = new Faker<CategoryForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10));

            var model = category.Generate();
            return model;
        }

        public IngredientForListVM IngredientGenerator()
        {
            var ingredient = new Faker<IngredientForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10))
                .RuleFor(o => o.Price, f => f.Random.Decimal(5, 100));

            var model = ingredient.Generate();
            return model;
        }

        public TagForListVM TagGenerator()
        {
            var tag = new Faker<TagForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10));

            var model = tag.Generate();
            return model;
        }

        public TypeForListVM TypeGenerator()
        {
            var type = new Faker<TypeForListVM>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 1))
                .RuleFor(o => o.Name, f => f.Random.String(5, 10));

            var model = type.Generate();
            return model;
        }
    }
}