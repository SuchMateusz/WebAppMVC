using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        private readonly ProductGeneratorHelper _generatorHelper;
        public TagValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewTagValidation();
            var command = _generatorHelper.GenerateTagForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_WrongId_ShouldReturnValidationErrorForWrongId()
        {
            var validator = new NewTagValidation();
            var command = _generatorHelper.GenerateTagForListVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TagForListVM.Id));
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_EmptyName_ShouldReturnValidationErrorForWrongId()
        {
            var validator = new NewTagValidation();
            var command = _generatorHelper.GenerateTagForListVM();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TagForListVM.Name));
        }

        [Fact]
        public void Add_TagValidation_ProperRequest_TooLongName_ShouldReturnValidationErrorForTooLongName()
        {
            var validator = new NewTagValidation();
            var command = _generatorHelper.GenerateTagForListVM();
            command.Name = "ThisTagNameWasCreateToProofThatNameIsTooLongForTag";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TagForListVM.Name));
        }
    }
}
