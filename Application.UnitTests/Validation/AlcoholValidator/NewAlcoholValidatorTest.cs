﻿using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.AlcoholValidator
{
    public class NewAlcoholValidatorTest
    {
        private readonly ProductGeneratorHelper _generatorHelper;

        public NewAlcoholValidatorTest()
        {
            _generatorHelper = new ProductGeneratorHelper();
        }

        [Fact]
        public void Add_NewAcoholValidation_ProperRequest_ShouldNotReturnValidationErrors()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WrongId_ShouldReturnValidationErrorForWrongId()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.Id));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_TooShortName_ShouldReturnValidationErrorForTooShortName()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.Name = "T";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.Name));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WrongTypeId_ShouldReturnValidationErrorForWrongTypeId()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.TypeId = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.TypeId));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WrongPriceValue_ShouldReturnValidationErrorForWrongPriceValue()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.Price = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.Price));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_EmptyPriceValue_ShouldReturnValidationErrorForEmptyPriceValue()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.Price = decimal.Zero;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.Price));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WrongYearProduction_ShouldReturnValidationErrorForWrongYearProduction()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.YearProduction = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.YearProduction));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_TooLowValueYearProduction_ShouldReturnValidationErrorForTooLowValueYearProduction()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.YearProduction = 814;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.YearProduction));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WronSugarContentd_ShouldReturnValidationErrorForWrongSugarContent()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.SugarContent = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.SugarContent));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WrongQuantity_ShouldReturnValidationErrorForWrongQuantity()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.Quantity = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.Quantity));
        }

        [Fact]
        public void Add_NewAcoholValidation_InvalidRequest_WrongAlcoholCategoryId_ShouldReturnValidationErrorForWrongAlcoholCategoryId()
        {
            var validator = new NewAlcoholValidation();
            var command = _generatorHelper.GenerateNewAlcoholForListVM();
            command.AlcoholCategoryId = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewAlcoholForListVM.AlcoholCategoryId));
        }


    }
}
