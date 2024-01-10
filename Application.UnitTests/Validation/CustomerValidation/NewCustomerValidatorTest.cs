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

        [Fact]
        public void Add_CustomerValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 1,
                Name = "Test",
                Password = "Password",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_WrongId_ShouldReturnValidationsErrorWrongId()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 0,
                Name = "Test",
                Password = "Password",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.Id));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_WrongNIP_ShouldReturnValidationsErrorWrongNIP()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 0,
                Name = "Test",
                Password = "Password",
                NIP = "12345678",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.NIP));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_WrongRegon_ShouldReturnValidationsErrorWrongRegon()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 0,
                Name = "Test",
                Password = "Password",
                NIP = "1234567890",
                REGON = "1234567",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.REGON));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_EmptyName_ShouldReturnValidationsErrorForNameIsEmpty()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 1,
                Password = "Password",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.Name));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_MissingEmailCharacter_ShouldReturnValidationsErrorMissingEmailCharacter()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 0,
                Name = "Test",
                Password = "Password",
                NIP = "1234567890",
                REGON = "12345678987",
                PhoneNumber = "1234567890",
                AddressEmail = "addressgmail.com",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.AddressEmail));
        }

        [Fact]
        public void Add_CustomerValidation_InvalidRequest_EmptyAddressEmail_ShouldReturnValidationsErrorEmptyAddressEmail()
        {
            var validator = new NewCustomerValidation();
            var command = new NewCustomerVM()
            {
                Id = 0,
                Name = "Test",
                Password = "Password",
                NIP = "1234567890",
                REGON = "12345678987",
                PhoneNumber = "1234567890",
                AddressEmail = "",
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(NewCustomerVM.AddressEmail));
        }

    }
}
