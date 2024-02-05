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
        private readonly ProductGeneratorHelper _generatorHelper;

        public DescriptionValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_DescriptionValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewDescriptionValidation();
            var command = _generatorHelper.GenerateDescriptionForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_DescriptionValidation_InvalidRequest_WrongId_ShouldReturnValidationErrorWrongId()
        {
            var validator = new NewDescriptionValidation();
            var command = _generatorHelper.GenerateDescriptionForListVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(DescriptionForListVM.Id));
        }

        [Fact]
        public void Add_DescriptionValidation_InvalidRequest_EmptyName_ShouldReturnValidationErrorEmptyName()
        {
            var validator = new NewDescriptionValidation();
            var command = _generatorHelper.GenerateDescriptionForListVM();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(DescriptionForListVM.Name));
        }

        [Fact]
        public void Add_DescriptionValidation_InvalidRequest_WrongName_ShouldReturnValidationErrorWrongName()
        {
            var validator = new NewDescriptionValidation();
            var command = _generatorHelper.GenerateDescriptionForListVM();
            command.Name = "Fis";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(DescriptionForListVM.Name));
        }

        [Fact]
        public void Add_DescriptionValidation_InvalidRequest_WrongDescription_ShouldReturnValidationErrorWrongDescription()
        {
            var validator = new NewDescriptionValidation();
            var command = _generatorHelper.GenerateDescriptionForListVM();
            command.Description = "Short";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(DescriptionForListVM.Description));
        }

        [Fact]
        public void Add_DescriptionValidation_InvalidRequest_EmptyDescription_ShouldReturnValidationErrorEmptyDescription()
        {
            var validator = new NewDescriptionValidation();
            var command = _generatorHelper.GenerateDescriptionForListVM();
            command.Description = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(DescriptionForListVM.Description));
        }
    }
}
