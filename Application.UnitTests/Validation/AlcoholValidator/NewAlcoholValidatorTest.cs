using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class NewAlcoholValidatorTest
    {
        [Fact]
        public void Add_NewAcoholValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewAlcoholValidation();
            var command = new NewAlcoholForListVM()
            {
                Id = 1,
                Name = "NameAlcohol",
                TypeId = 1,
                Price = 1,
                YearProduction = 2012,
                SugarContent = 1,
                Quantity = 1,
                AlcoholCategoryId = 1,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}
