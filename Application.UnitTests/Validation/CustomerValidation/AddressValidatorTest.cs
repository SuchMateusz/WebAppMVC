using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.CustomerValidation
{
    public class AddressValidatorTest
    {
        private readonly CustomerGeneratorHelper _customerGeneratorHelper;

        public AddressValidatorTest()
        {
            _customerGeneratorHelper = new CustomerGeneratorHelper();
        }

        [Fact]
        public void Add_AddressValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new NewAddressValidation();
            var command = _customerGeneratorHelper.GenerateAddressForListVM();


            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_WrongId_ShouldReturnValidationsErrorForWrongId()
        {
            var validator = new NewAddressValidation();
            var command = _customerGeneratorHelper.GenerateAddressForListVM();
            command.Id = 0;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.Id));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_EmptyBuildingNumber_ShouldReturnValidationsErrorForEmptyBuildingNumber()
        {
            var validator = new NewAddressValidation();
            var command = _customerGeneratorHelper.GenerateAddressForListVM();
            command.BuildingNumber = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.BuildingNumber));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_TooLongBuildingNumber_ShouldReturnValidationsErrorForEmptyTooLongBuildingNumber()
        {
            var validator = new NewAddressValidation();
            var command = _customerGeneratorHelper.GenerateAddressForListVM();
            command.BuildingNumber = "1000000A";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.BuildingNumber));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_WrongNameStreet_ShouldReturnValidationsErrorForWrongStreetName()
        {
            var validator = new NewAddressValidation();
            var command = _customerGeneratorHelper.GenerateAddressForListVM();
            command.Street = "As";

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.Street));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_EmptyCityName_ShouldReturnValidationsErrorForEmptyWrongStreetName()
        {
            var validator = new NewAddressValidation();
            var command = _customerGeneratorHelper.GenerateAddressForListVM();
            command.City = string.Empty;

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.City));
        }
    }
}
