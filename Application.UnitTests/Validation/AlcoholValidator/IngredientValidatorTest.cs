using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class IngredientValidatorTest
    {
        private readonly ProductGeneratorHelper _generatorHelper;

        public IngredientValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_IngredientValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewIngredientValidation();
            var command = _generatorHelper.GenerateIngredientForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_WrongId_ShouldReturnValidationErrorsWrongId()
        {
            var validator = new NewIngredientValidation();
            var command = _generatorHelper.GenerateIngredientForListVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Id));
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_WrongName_ShouldReturnValidationErrorsWrongName()
        {
            var validator = new NewIngredientValidation();
            var command = _generatorHelper.GenerateIngredientForListVM();
            command.Name = "In";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Name));
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_EmptyName_ShouldReturnValidationErrorsEmptyName()
        {
            var validator = new NewIngredientValidation();
            var command = _generatorHelper.GenerateIngredientForListVM();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Name));
        }

                [Fact]
        public void Add_IngredientValidation_InvalidRequest_WrongPrice_ShouldReturnValidationErrorsWrongPrice()
        {
            var validator = new NewIngredientValidation();
            var command = _generatorHelper.GenerateIngredientForListVM();
            command.Price = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Price));
        }
    }
}
