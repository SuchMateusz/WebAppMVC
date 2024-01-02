using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class DescriptionValidatorTest
    {
        [Fact]
        public void Add_DescriptionValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewDescriptionValidation();
            var command = new DescriptionForListVM()
            {
                Id = 1,
                Description = "This is big description this product",
                Name = "Description theme",
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }


    }
}
