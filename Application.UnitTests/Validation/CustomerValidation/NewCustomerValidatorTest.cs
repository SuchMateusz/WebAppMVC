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
                NIP = "126456489",
                REGON = "1345",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
            };

            validator.TestValidate(command).ShouldNotHaveAnyValidationErrors();
        }
    }
}
