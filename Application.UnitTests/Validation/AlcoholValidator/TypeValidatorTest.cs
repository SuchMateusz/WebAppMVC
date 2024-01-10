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

        [Fact]
        public void Add_TypeValidation_ProperRequest_WrongId_ShouldReturnValidationErrorWrongId()
        {
            var validator = new NewTypeValidation();
            var command = new TypeForListVM()
            {
                Name = "TypeName",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TypeForListVM.Id));
        }

        [Fact]
        public void Add_TypeValidation_ProperRequest__EmptyName_ShouldReturnValidationErrorForEmptyName()
        {
            var validator = new NewTypeValidation();
            var command = new TypeForListVM()
            {
                Id = 1,
                Name = "",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TypeForListVM.Name));
        }

        [Fact]
        public void Add_TypeValidation_ProperRequest_TooLongName_ShouldReturnValidationErrorForTooLongName()
        {
            var validator = new NewTypeValidation();
            var command = new TypeForListVM()
            {
                Id = 1,
                Name = "ThisTypeNameWasCreateToProofThatNameIsTooLongForTypeIQuess",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TypeForListVM.Name));
        }
    }
}