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
        private readonly ProductGeneratorHelper _generatorHelper;
        public TypeValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_TypeValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewTypeValidation();
            var command = _generatorHelper.GenerateTypeForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_TypeValidation_ProperRequest_WrongId_ShouldReturnValidationErrorWrongId()
        {
            var validator = new NewTypeValidation();
            var command = _generatorHelper.GenerateTypeForListVM();
            command.Id = 0;

        validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TypeForListVM.Id));
        }

        [Fact]
        public void Add_TypeValidation_ProperRequest__EmptyName_ShouldReturnValidationErrorForEmptyName()
        {
            var validator = new NewTypeValidation();
            var command = _generatorHelper.GenerateTypeForListVM();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TypeForListVM.Name));
        }

        [Fact]
        public void Add_TypeValidation_ProperRequest_TooLongName_ShouldReturnValidationErrorForTooLongName()
        {
            var validator = new NewTypeValidation();
            var command = _generatorHelper.GenerateTypeForListVM();
            command.Name = "ThisTypeNameWasCreateToProofThatNameIsTooLongForTypeIQuess";
      
            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(TypeForListVM.Name));
        }
    }
}