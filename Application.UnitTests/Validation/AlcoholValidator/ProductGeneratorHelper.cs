using Bogus;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class ProductGeneratorHelper
    {
        public AlcoholForListVM GenerateAlcoholForListVM()
        {
            return new Faker<AlcoholForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10))
                .RuleFor(x => x.TypeId, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Price, f => f.Random.Decimal(1, 50))
                .RuleFor(x => x.YearProduction, f => f.Random.Int(1980, 2024))
                .RuleFor(x => x.SugarContent, f => f.Random.Float(0, 30))
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 50))
                .RuleFor(x => x.AlcoholCategoryId, f => f.Random.Int(1, 1)); ;
        }
        
        public NewAlcoholForListVM GenerateNewAlcoholForListVM()
        {
            return new Faker<NewAlcoholForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10))
                .RuleFor(x => x.TypeId, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Price, f => f.Random.Decimal(1, 50))
                .RuleFor(x => x.YearProduction, f => f.Random.Int(1980, 2024))
                .RuleFor(x => x.SugarContent, f => f.Random.Float(0, 30))
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 50))
                .RuleFor(x => x.AlcoholCategoryId, f => f.Random.Int(1, 1)); ;
        }

        public AlcoholIngredientsForListVM GenerateAlcoholIngredientsForListVM()
        {
            return new Faker<AlcoholIngredientsForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10))
                .RuleFor(x => x.AlcoholRef, f => f.Random.Int(1, 1));;
        }

        public DescriptionForListVM GenerateDescriptionForListVM()
        {
            return new Faker<DescriptionForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10))
                .RuleFor(x => x.Description, f => f.Random.Words(10)); ;
        }

        public CategoryForListVM GenerateCategoryForListVM()
        {
            return new Faker<CategoryForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10)); ;
        }

        public IngredientForListVM GenerateIngredientForListVM()
        {
            return new Faker<IngredientForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10))
                .RuleFor(x => x.Price, f => f.Random.Decimal(5, 100)); ;
        }

        public TagForListVM GenerateTagForListVM()
        {
            return new Faker<TagForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10)); ;
        }

        public TypeForListVM GenerateTypeForListVM()
        {
            return new Faker<TypeForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10)); ;
        }
    }
}