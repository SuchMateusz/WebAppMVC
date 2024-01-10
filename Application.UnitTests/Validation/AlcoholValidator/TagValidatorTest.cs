using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class TagValidatorTest
    {

        [Fact]
        public void Add_TagValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewTagValidation();
            var command = new TagForListVM()
            {
                Id = 1,
                Name = "TagName",
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_WrongId_ShouldReturnValidationErrorForWrongId()
        {
            var validator = new NewTagValidation();
            var command = new TagForListVM()
            {
                Id = 0,
                Name = "TagName",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TagForListVM.Id));
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_EmptyName_ShouldReturnValidationErrorForWrongId()
        {
            var validator = new NewTagValidation();
            var command = new TagForListVM()
            {
                Id = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TagForListVM.Name));
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_TooLongName_ShouldReturnValidationErrorForTooLongName()
        {
            var validator = new NewTagValidation();
            var command = new TagForListVM()
            {
                Id = 1,
                Name = "ThisTagNameWasCreateToProofThatNameIsTooLongForTag",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TagForListVM.Name));
        }
    }
}
