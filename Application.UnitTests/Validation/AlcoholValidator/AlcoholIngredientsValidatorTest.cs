using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Model;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class AlcoholIngredientsValidatorTest
    {
        IngredientForListVM ingredient = new IngredientForListVM()
        {
            Id = 1,
            Name = "Test",
            Price = 1,
        };

        AlcoholForListVM alcohol = new AlcoholForListVM()
        {
            Id = 1,
            Name = "Mati",
            TypeId = 1,
            Price = 10,
            YearProduction = 2000,
            SugarContent = 50,
            Quantity = 15,
            AlcoholCategoryId = 1
        };

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 1,
                Name = "Test",
                Ingredient = ingredient,
                Item = alcohol,
                AlcoholRef = 1,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_WrongId_ShouldReturnValidationsErrorForAlcoholIngredientId()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 0,
                Name = "Test",
                Ingredient = ingredient,
                Item = alcohol,
                AlcoholRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Id));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_WrongAlcoholRef_ShouldReturnValidationsErrorForAlcoholRef()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 1,
                Name = "Test",
                Ingredient = ingredient,
                Item = alcohol,
                AlcoholRef = 0,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.AlcoholRef));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_WrongName_ShouldReturnValidationsErrorForAlcoholIngredientName()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 1,
                Name = "T",
                Ingredient = ingredient,
                Item = alcohol,
                AlcoholRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Name));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_EmpyIngredient_ShouldReturnValidationsErrorForEmptyIngredient()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 1,
                Name = "Test",
                Item = alcohol,
                AlcoholRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Ingredient));
        }

        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_EmpyAlcohol_ShouldReturnValidationsErrorForEmptyAlcohol()
        {
            var validator = new AlcoholIngredientsValidation();
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 1,
                Name = "Test",
                Ingredient = ingredient,
                AlcoholRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholIngredientsForListVM.Item));
        }
    }
}