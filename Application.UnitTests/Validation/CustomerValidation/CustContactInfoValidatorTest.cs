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
        private readonly CustomerGeneratorHelper _generatorHelper;

        public CustContactInfoValidatorTest()
        {
            _generatorHelper = new CustomerGeneratorHelper();
        }

        [Fact]
        public void Add_CustContactInfoValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongId_ShouldReturnValidationsErrorForWrongId()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.Id = 0;


            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Id));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyName_ShouldReturnValidationsErrorForEmptyName()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.Name = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Name));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_ShortName_ShouldReturnValidationsErrorForTooShortName()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.Name = "A";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Name));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyLastName_ShouldReturnValidationsErrorForEmptyLastName()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.LastNameUser = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.LastNameUser));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyPosition_ShouldReturnValidationsErrorForEmptyPosition()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.Position = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.Position));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyAddresEmail_ShouldReturnValidationsErrorForEmptyAddressEmail()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.DirectPersonAddressEmail = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPersonAddressEmail));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongAddresEmail_ShouldReturnValidationsErrorForWrongAddressEmail()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.DirectPersonAddressEmail = "Alagmail.com";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPersonAddressEmail));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_EmptyPhoneNumber_ShouldReturnValidationsErrorForEmptyPhoneNumber()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.DirectPhoneNumber = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPhoneNumber));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongPhoneNumber_ShouldReturnValidationsErrorForWrongPhoneNumber()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.DirectPhoneNumber = "112";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.DirectPhoneNumber));
        }

        [Fact]
        public void Add_CustContactInfoValidation_InvalidRequest_WrongCustomerRef_ShouldReturnValidationsErrorForWrongCustomerRef()
        {
            var validator = new NewCustomerContactInformactionValidation();
            var command = _generatorHelper.GenerateCustomerContactInfForListVM();
            command.CustomerRef = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(CustomerContactInformactionForListVm.CustomerRef));
        }
    }
}
