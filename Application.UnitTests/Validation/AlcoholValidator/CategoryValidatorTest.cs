using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class CategoryValidatorTest
    {
        [Fact]
        public void Add_CategoryValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewCategoryValidation();
            var command = new CategoryForListVM()
            {
                Id = 1,
                Name = "Wine",
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}
