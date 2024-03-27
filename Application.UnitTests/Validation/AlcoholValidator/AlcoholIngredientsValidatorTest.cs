using FluentValidation.TestHelper;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Model;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class AlcoholIngredientsValidatorTest
    {
        private readonly ProductGeneratorHelper _generatorHelper;

        public AlcoholIngredientsValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.GenerateAlcoholIngredientsForListVM();
            command.Ingredient = _generatorHelper.GenerateIngredientForListVM();
            command.Alcohol = _generatorHelper.GenerateAlcoholForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_WrongId_ShouldReturnValidationsErrorForAlcoholIngredientId()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.GenerateAlcoholIngredientsForListVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Id));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_WrongAlcoholRef_ShouldReturnValidationsErrorForAlcoholRef()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.GenerateAlcoholIngredientsForListVM();
            command.AlcoholRef = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.AlcoholRef));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_EmptyIngredient_ShouldReturnValidationsErrorForEmptyIngredient()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.GenerateAlcoholIngredientsForListVM();
            command.Ingredient = null;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Ingredient));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_EmpyAlcohol_ShouldReturnValidationsErrorForEmptyAlcohol()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.GenerateAlcoholIngredientsForListVM();
            command.Alcohol = null;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Alcohol));
        }
    }
}