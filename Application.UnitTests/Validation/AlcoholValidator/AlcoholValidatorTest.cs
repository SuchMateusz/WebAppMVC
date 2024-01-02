using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class AlcoholValidatorTest
    {
        [Fact]
        public void Add_AlcoholValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
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

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}
