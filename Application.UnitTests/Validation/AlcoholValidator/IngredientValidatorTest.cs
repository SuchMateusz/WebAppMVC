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

        [Fact]
        public void Add_IngredientValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewIngredientValidation();
            var command = new IngredientForListVM()
            {
                Id = 1,
                Name = "Ingredient",
                Price = 10,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_WrongId_ShouldReturnValidationErrorsWrongId()
        {
            var validator = new NewIngredientValidation();
            var command = new IngredientForListVM()
            {
                Id = 0,
                Name = "Ingredient",
                Price = 10,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Id));
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_WrongName_ShouldReturnValidationErrorsWrongName()
        {
            var validator = new NewIngredientValidation();
            var command = new IngredientForListVM()
            {
                Id = 1,
                Name = "In",
                Price = 10,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Name));
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_EmptyName_ShouldReturnValidationErrorsEmptyName()
        {
            var validator = new NewIngredientValidation();
            var command = new IngredientForListVM()
            {
                Id = 1,
                Price = 10,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Name));
        }

                [Fact]
        public void Add_IngredientValidation_InvalidRequest_WrongPrice_ShouldReturnValidationErrorsWrongPrice()
        {
            var validator = new NewIngredientValidation();
            var command = new IngredientForListVM()
            {
                Id = 1,
                Name = "Ingredient",
                Price = 0,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Price));
        }

        [Fact]
        public void Add_IngredientValidation_InvalidRequest_EmptyPrice_ShouldReturnValidationErrorsEmptyPrice()
        {
            var validator = new NewIngredientValidation();
            var command = new IngredientForListVM()
            {
                Id = 1,
                Name = "Ingredient",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(IngredientForListVM.Price));
        }

    }
}
