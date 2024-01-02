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
    }
}
