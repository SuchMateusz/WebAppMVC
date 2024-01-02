using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class AlcoholIngredientsValidatorTest
    {
        [Fact]
        public void Add_AlcoholIngredientsValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new AlcoholIngredientsValidation();
            var ingrediente = new IngredientForListVM()
            {
                Id = 1,
                Name = "Test",
                Price = 1,
            };
            var command = new AlcoholIngredientsForListVM()
            {
                Id = 1,
                Name = "Test",
                Ingredient = ingrediente,
                AlcoholRef = 1,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}
