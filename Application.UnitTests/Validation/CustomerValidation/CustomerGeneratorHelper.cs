using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Application.ViewModel.Item;

namespace Application.UnitTests.Validation.CustomerValidation
{
    public class CustomerGeneratorHelper
    {
        public AddressForListVM GenerateAddressForListVM()
        {
            return new Faker<AddressForListVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.BuildingNumber, f => f.Address.BuildingNumber())
                .RuleFor(x => x.Street, f => f.Address.StreetName())
                .RuleFor(x => x.ZipCode, f => f.Address.ZipCode())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Country, f => f.Address.Country())
                .RuleFor(x => x.CustomerId, f => f.Random.Int(1, 1));
        }

        public CustomerContactInformactionForListVm GenerateCustomerContactInfForListVM()
        {
            return new Faker<CustomerContactInformactionForListVm>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.LastNameUser, f => f.Person.LastName)
                .RuleFor(x => x.DirectPersonAddressEmail, f => f.Internet.Email())
                .RuleFor(x => x.DirectPhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Position, f => f.Name.JobTitle())
                .RuleFor(x => x.CustomerRef, f => f.Random.Int(1,1));
        }

        public NewCustomerVM GenerateNewCustomerVM()
        {
            return new Faker<NewCustomerVM>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 1))
                .RuleFor(x => x.Name, f => f.Random.String(5, 10))
                .RuleFor(x => x.Password, f => f.Internet.Password())
                .RuleFor(x => x.NIP, f => f.Random.String(length: 10))
                .RuleFor(x => x.REGON, f => f.Random.String(9, 14))
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.AddressEmail, f => f.Internet.Email()); ;
        }
    }
}
