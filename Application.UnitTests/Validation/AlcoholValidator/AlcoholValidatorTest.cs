using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Model;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class AlcoholValidatorTest
    {
        private readonly ProductGeneratorHelper _generatorHelper;

        public AlcoholValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_AlcoholValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();

            validator.TestValidate(alcohol).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongId_ShouldReturnValidationErrorForWrongAlcoholId()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.Id = 0;

            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Id));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_EmptyName_ShouldReturnValidationErrorEmptyName()
        {
            var validator = new AlcoholValidation();
            var command = _generatorHelper.AlcoholGenerator();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Name));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_ToShortName_ShouldReturnValidationErrorShortName()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.Name = "M";

            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Name));
        }


        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongTypeId_ShouldReturnValidationErrorWrongTypeId()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.TypeId = 0;


            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.TypeId));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongAlcoholCategoryId_ShouldReturnValidationErrorWrongAlcoholCategoryId()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.AlcoholCategoryId = 0;

            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.AlcoholCategoryId));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_WrongPriceValue_ShouldReturnValidationErrorWrongPriceValue()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.Price = 0;

            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.Price));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequestRequest_EmptyValueYearProduction_ShouldReturnValidationErrorMissingYearProduction()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.YearProduction = 0;

            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.YearProduction));
        }

        [Fact]
        public void Add_AlcoholValidation_InvalidRequest_WrongValueYearProduction_ShouldReturnValidationErrorYearProduction()
        {
            var validator = new AlcoholValidation();
            var alcohol = _generatorHelper.AlcoholGenerator();
            alcohol.YearProduction = 30;

            validator.TestValidate(alcohol).ShouldHaveValidationErrorFor(nameof(AlcoholForListVM.YearProduction));
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