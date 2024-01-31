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
            var command = _generatorHelper.NewAlcoholIngredientGenerator();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_WrongId_ShouldReturnValidationsErrorForAlcoholIngredientId()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.NewAlcoholIngredientGenerator();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Id));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_WrongAlcoholRef_ShouldReturnValidationsErrorForAlcoholRef()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.NewAlcoholIngredientGenerator();
            command.AlcoholRef = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.AlcoholRef));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_WrongName_ShouldReturnValidationsErrorForAlcoholIngredientName()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.NewAlcoholIngredientGenerator();
            command.Name = "T";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Name));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_EmptyIngredient_ShouldReturnValidationsErrorForEmptyIngredient()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.NewAlcoholIngredientGenerator();
            command.Ingredient = null;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Ingredient));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_InvalidRequestRequest_EmpyAlcohol_ShouldReturnValidationsErrorForEmptyAlcohol()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = _generatorHelper.NewAlcoholIngredientGenerator();
            command.Item = null;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Item));
        }
    }
}