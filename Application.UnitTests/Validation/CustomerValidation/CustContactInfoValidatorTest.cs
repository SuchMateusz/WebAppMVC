using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Customer;
using static WebAppMVC.Application.ViewModel.Customer.CustomerContactInformactionForListVm;

namespace Application.UnitTests.Validation.CustomerValidation
{
    public class CustContactInfoValidatorTest
    {

        [Fact]
        public void Add_CustContactInfoValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                Position ="CEO",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongId_ShouldReturnValidationsErrorForWrongId()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 0,
                Name = "Test",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Id));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyName_ShouldReturnValidationsErrorForEmptyName()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Name));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_ShortName_ShouldReturnValidationsErrorForTooShortName()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "A",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Name));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyLastName_ShouldReturnValidationsErrorForEmptyLastName()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Adrian",
                Position = "CEO",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.LastNameUser));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyPosition_ShouldReturnValidationsErrorForEmptyPosition()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Position));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyAddresEmail_ShouldReturnValidationsErrorForEmptyAddressEmail()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPersonAddressEmail));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongAddresEmail_ShouldReturnValidationsErrorForWrongAddressEmail()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Alagmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPersonAddressEmail));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyPhoneNumber_ShouldReturnValidationsErrorForEmptyPhoneNumber()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Alagmail.com",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPhoneNumber));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongPhoneNumber_ShouldReturnValidationsErrorForWrongPhoneNumber()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Alagmail.com",
                DirectPhoneNumber = "112",
                CustomerRef = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPhoneNumber));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongCustomerRef_ShouldReturnValidationsErrorForWrongCustomerRef()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = new CustomerContactInformactionForListVm()
            {
                Id = 1,
                Name = "Test",
                LastNameUser = "LastName",
                Position = "CEO",
                DirectPersonAddressEmail = "Ala@gmail.com",
                DirectPhoneNumber = "12413561",
                CustomerRef = 0,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.CustomerRef));
        }
    }
}
