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
                City = "1",
                Country = "2",
                CustomerId = 1,
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}
