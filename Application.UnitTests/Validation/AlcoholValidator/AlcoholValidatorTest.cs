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
                Name = "Test",
                TypeId = 1,
                Price = 10,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongId_ShouldReturnValidationErrorForWrongAlcoholId()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 0,
                Name = "Test",
                TypeId = 1,
                Price = 10,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Id));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_EmptyName_ShouldReturnValidationErrorEmptyName()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                TypeId = 1,
                Price = 10,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Name));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_ToShortName_ShouldReturnValidationErrorShortName()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "M",
                TypeId = 1,
                Price = 10,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Name));
        }


        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongTypeId_ShouldReturnValidationErrorWrongTypeId()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 0,
                Price = 10,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.TypeId));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongAlcoholCategoryId_ShouldReturnValidationErrorWrongAlcoholCategoryId()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 1,
                Price = 10,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 0,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.AlcoholCategoryId));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongPriceValue_ShouldReturnValidationErrorWrongPriceValue()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 1,
                Price = 0,
                YearProduction = 2000,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Price));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_EmptyValueYearProduction_ShouldReturnValidationErrorMissingYearProduction()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 1,
                Price = 1,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.YearProduction));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequest_WrongValueYearProduction_ShouldReturnValidationErrorYearProduction()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 1,
                Price = 1,
                YearProduction = 50,
                SugarContent = 50,
                Quantity = 15,
                AlcoholCategoryId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.YearProduction));
        }


        [Fact]
        public void Add_AlcoholValidation_InvalidRequest_EmptyValueQuantity_ShouldReturnValidationErrorMissingQuantity()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 1,
                Price = 1,
                SugarContent = 2050,
                AlcoholCategoryId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Quantity));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequest_WrongValueQuantity_ShouldReturnValidationErrorQuantity()
        {
            var validator = new AlcoholValidation();
            var command = new AlcoholForListVM()
            {
                Id = 1,
                Name = "TestName",
                TypeId = 1,
                Price = 1,
                YearProduction = 50,
                SugarContent = 50,
                Quantity = 0,
                AlcoholCategoryId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.YearProduction));
        }
    }
}