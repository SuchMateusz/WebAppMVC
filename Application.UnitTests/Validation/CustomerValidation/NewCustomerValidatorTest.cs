using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Customer;

namespace Application.UnitTests.Validation.CustomerValidation
{
    public class NewCustomerValidatorTest
    {
        private readonly CustomerGeneratorHelper _generatorHelper;

        public NewCustomerValidatorTest()
        {
            _generatorHelper = new CustomerGeneratorHelper();
        }

        [Fact]
        public void Add_CustomerValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_WrongId_ShouldReturnValidationsErrorWrongId()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.Id));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_WrongNIP_ShouldReturnValidationsErrorWrongNIP()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM();
            command.NIP = "12345678";
                
            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.NIP));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_WrongRegon_ShouldReturnValidationsErrorWrongRegon()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM(); 
            command.REGON = "1234567";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.REGON));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_EmptyName_ShouldReturnValidationsErrorForNameIsEmpty()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.Name));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_MissingEmailCharacter_ShouldReturnValidationsErrorMissingEmailCharacter()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM(); 
            command.AddressEmail = "addressgmail.com";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.AddressEmail));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_EmptyAddressEmail_ShouldReturnValidationsErrorEmptyAddressEmail()
        {
            var validator = new NewCustomerValidation();
            var command = _generatorHelper.GenerateNewCustomerVM();
            command.AddressEmail = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.AddressEmail));
        }

    }
}
