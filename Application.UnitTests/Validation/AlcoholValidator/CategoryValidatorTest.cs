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

        [Fact]
        public void Add_CategoryValidation_InvalidRequest_WrongId_ShouldReturnValidationErrorWrongId()
        {
            var validator = new NewCategoryValidation();
            var command = new CategoryForListVM()
            {
                Id = 0,
                Name = "Wine",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CategoryForListVM.Id));
        }

        [Fact]
        public void Add_CategoryValidation_InvalidRequest_EmptyName_ShouldReturnValidationErrorEmptyName()
        {
            var validator = new NewCategoryValidation();
            var command = new CategoryForListVM()
            {
                Id = 1,
                Name = "",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CategoryForListVM.Name));
        }

        [Fact]
        public void Add_CategoryValidation_InvalidRequest_WrongName_ShouldReturnValidationErrorWrongName()
        {
            var validator = new NewCategoryValidation();
            var command = new CategoryForListVM()
            {
                Id = 1,
                Name = "Fi"
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CategoryForListVM.Name));
        }
    }
}
