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

        [Fact]
        public void Add_AddressValidation_ProperRequest_ShouldNotReturnValidationsErrors()
        {
            var validator = new NewAddressValidation();
            var command = new AddressForListVM()
            {
                Id = 1,
                BuildingNumber = "10",
                Street = "St. Luis",
                ZipCode = "2",
                City = "Rzeszów",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_WrongId_ShouldReturnValidationsErrorForWrongId()
        {
            var validator = new NewAddressValidation();
            var command = new AddressForListVM()
            {
                Id = 0,
                BuildingNumber = "10",
                Street = "St. Luis",
                ZipCode = "2",
                City = "Wrocław",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.Id));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_EmptyBuildingNumber_ShouldNotReturnValidationsErrorForEmptyBuildingNumber()
        {
            var validator = new NewAddressValidation();
            var command = new AddressForListVM()
            {
                Id = 1,
                Street = "St. Luis",
                ZipCode = "2",
                City = "Kraków",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.BuildingNumber));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_TooLongBuildingNumber_ShouldNotReturnValidationsErrorForEmptyTooLongBuildingNumber()
        {
            var validator = new NewAddressValidation();
            var command = new AddressForListVM()
            {
                Id = 1,
                BuildingNumber = "10000A",
                Street = "St. Luis",
                ZipCode = "2",
                City = "Warsaw",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.BuildingNumber));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_WrongNameStreet_ShouldNotReturnValidationsErrorForEmptyWrongStreetName()
        {
            var validator = new NewAddressValidation();
            var command = new AddressForListVM()
            {
                Id = 1,
                BuildingNumber = "127A",
                Street = "As",
                ZipCode = "2",
                City = "Warsaw",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.Street));
        }

        [Fact]
        public void Add_AddressValidation_InvalidRequest_EmptyCityName_ShouldNotReturnValidationsErrorForEmptyWrongStreetName()
        {
            var validator = new NewAddressValidation();
            var command = new AddressForListVM()
            {
                Id = 1,
                BuildingNumber = "127A",
                Street = "As",
                ZipCode = "2",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldHaveValidationErrorFor(nameof(AddressForListVM.City));
        }


    }
}
