using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class TypeValidatorTest
    {
        [Fact]
        public void Add_TypeValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewTypeValidation();
            var command = new TypeForListVM()
            {
                Id = 1,
                Name = "TypeName",
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}