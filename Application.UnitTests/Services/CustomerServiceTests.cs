using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Application.Services;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;
using WebAppMVC.Infrastructure.Repositories;

namespace Application.UnitTests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepo;
        private readonly Mock<IAddressesRepository> _addressesRepo;
        private readonly Mock<ICustContInfoRepository> _custContInfoRepo;
        private readonly IMapper _mapper;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _customerRepo = new Mock<ICustomerRepository>();
            _addressesRepo = new Mock<IAddressesRepository> ();
            _custContInfoRepo = new Mock<ICustContInfoRepository>();
            _customerService = new CustomerService(_customerRepo.Object, _addressesRepo.Object, _custContInfoRepo.Object, _mapper);
        }

        [Fact]
        public void AddNewCustomer_ProperRequest_ProvidingAddNewCustomerSucced()
        {
            //Arrange
            var customer = new Customer()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Password = "Password!@12",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
                isActive = true,
            };

            var model = _mapper.Map<NewCustomerVM>(customer);
            _customerRepo.Setup(r => r.AddCustomer(It.IsAny<Customer>())).Callback<Customer>(i => customer = i).Returns(1);

            //Act
            int id = _customerService.AddCustomer(model);

            //Assert
            _customerRepo.Verify(r => r.AddCustomer(It.IsAny<Customer>()), Times.Once());
             id.Should().Be(1);
        }

        [Fact]
        public void GetCustomerToEdit_ProperRequest_ProvidingGetCustomerForEditWasSucced()
        {
            //Arrange
            var customer = new Customer()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Password = "Password!@12",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
                isActive = true,
            };

            var model = _mapper.Map<NewCustomerVM>(customer);
            _customerRepo.Setup(r => r.GetCustomer(customer.Id)).Returns(customer);

            //Act
            var returnedModel = _customerService.GetCustomerForEdit(model.Id);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(customer.Name);
        }

        [Fact]
        public void UpdateCustomer_ProperRequest_ProvidingUpdateCustomerWasSucced()
        {
            //Arrange
            var customer = new Customer()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Password = "Password!@12",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
                isActive = true,
            };

            var model = _mapper.Map<NewCustomerVM>(customer);
            
            //Act
            _customerService.UpdateCustomer(model);

            //Assert
            _customerRepo.Verify(r => r.UpdateCustomer(It.IsAny<Customer>()), Times.Once());
        }
        //public ListCustomerForListVM GetAllCustomerForList(int pageSize, int pageNo, string searchString)

        [Fact]
        public void DeleteCustomer_ProperRequest_ProvidingDeletedCustomerWasSucced()
        {
            //Arrange
            var customer = new Customer()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Password = "Password!@12",
                NIP = "1234567890",
                REGON = "123456789",
                PhoneNumber = "1234567890",
                AddressEmail = "address@gmail.com",
                isActive = true,
            };
            //Act
            _customerService.DeleteCustomer(customer.Id);

            //Assert
            _customerRepo.Verify(r => r.DeleteCustomer(customer.Id), Times.Once());
        }

        [Fact]
        public void AddNewAddressCustomer_ProperRequest_ProvidingToAddNewCustomerAddressSucced()
        {
            //Arrange
            var address = new Address()
            {
                Id = 1,
                Name = "Industrial Robotic Email",
                BuildingNumber = "222F",
                Street = "Rzeszowska",
                ZipCode = "31-232",
                City = "Warsaw",
                Country = "Poland",
                CustomerId = 1,    
            };

            var model = _mapper.Map<AddressForListVM>(address);
            _addressesRepo.Setup(r => r.AddAddresses(It.IsAny<Address>())).Callback<Address>(i => address = i).Returns(1);

            //Act
            int id = _customerService.AddAddressModel(model);

            //Assert
            _addressesRepo.Verify(r => r.AddAddresses(It.IsAny<Address>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void GetAddressCustomerForEdit_ProperRequest_ProvidingToGetCustomerAddressWasucced()
        {
            //Arrange
            var address = new Address()
            {
                Id = 1,
                Name = "Industrial Robotic Email",
                BuildingNumber = "222F",
                Street = "Rzeszowska",
                ZipCode = "31-232",
                City = "Warsaw",
                Country = "Poland",
                CustomerId = 1,
            };

            var model = _mapper.Map<AddressForListVM>(address);
            _addressesRepo.Setup(r => r.GetAddressById(address.Id)).Returns(address);

            //Act
            var returnedModel = _customerService.GetAddressForEdit(model.Id);

            //Assert
            _addressesRepo.Verify(r => r.GetAddressById(model.Id), Times.Once());
            returnedModel.Id.Should().Be(1);
            returnedModel.BuildingNumber.Should().Be(address.BuildingNumber);

        }
        //public ListAddressForListVM GetAllAddressCustomer(int pageSize, int pageNo, int customerId)


        [Fact]
        public void UpdateAddress_ProperRequest_ProvidingToUpdateCustomerAddressWasSucced()
        {
            //Arrange
            var address = new Address()
            {
                Id = 1,
                Name = "Industrial Robotic Email",
                BuildingNumber = "222F",
                Street = "Rzeszowska",
                ZipCode = "31-232",
                City = "Warsaw",
                Country = "Poland",
                CustomerId = 1,
            };

            var model = _mapper.Map<AddressForListVM>(address);
            //Act
            _customerService.UpdateAddress(model);

            //Assert
            _addressesRepo.Verify(r => r.UpdateAddress(It.IsAny<Address>()), Times.Once());
        }

        [Fact]
        public void AddNewCustomerContact_ProperRequest_ProvidingToAddNewCustomerContactSucced()
        {
            //Arrange
            var contactCustomer = new CustomerContactInformaction()
            {
                Id = 1,
                Name = "Pjeter",
                LastNameUser = "Blabla",
                Position = "CEO",
                DirectPersonAddressEmail = "PjeterBla@gmail.com",
                DirectPhoneNumber = "789456123",
                CustomerRef = 1,
            };

            var model = _mapper.Map<CustomerContactInformactionForListVm>(contactCustomer);
            _custContInfoRepo.Setup(r => r.AddCustomerContactInformaction(It.IsAny<CustomerContactInformaction>())).Callback<CustomerContactInformaction>(i => contactCustomer = i).Returns(1);

            //Act
            int id = _customerService.AddCustomerContactInformaction(model);

            //Assert
            _custContInfoRepo.Verify(r => r.AddCustomerContactInformaction(It.IsAny<CustomerContactInformaction>()), Times.Once());
            id.Should().Be(1);
        }
        //public ListCustomerContactInformactionForListVm GetCustConDetails(int pageSize, int pageNo, int customerContactDetail)


        [Fact]
        public void GetCustomerContact_ProperRequest_ProvidingToGetCustomerContactToEditSucced()
        {
            //Arrange
            var contactCustomer = new CustomerContactInformaction()
            {
                Id = 1,
                Name = "Pjeter",
                LastNameUser = "Blabla",
                Position = "CEO",
                DirectPersonAddressEmail = "PjeterBla@gmail.com",
                DirectPhoneNumber = "789456123",
                CustomerRef = 1,
            };
            var model = _mapper.Map<CustomerContactInformactionForListVm>(contactCustomer);
            _custContInfoRepo.Setup(r => r.GetCustContactById(contactCustomer.Id)).Returns(contactCustomer);

            //Act
            var returnedModel = _customerService.GetCustContactForEdit(model.Id);

            //Assert
            _custContInfoRepo.Verify(r => r.GetCustContactById(contactCustomer.Id), Times.Once());
            returnedModel.Id.Should().Be(contactCustomer.Id);
            returnedModel.Name.Should().Be(contactCustomer.Name);
            returnedModel.LastNameUser.Should().Be(contactCustomer.LastNameUser);
            returnedModel.Position.Should().Be(contactCustomer.Position);
            returnedModel.DirectPhoneNumber.Should().Be(contactCustomer.DirectPhoneNumber);
        }

        [Fact]
        public void UpdateCustomerContact_ProperRequest_ProvidingToUpdateCustomerContactToSucced()
        {
            //Arrange
            var contactCustomer = new CustomerContactInformaction()
            {
                Id = 1,
                Name = "Pjeter",
                LastNameUser = "Blabla",
                Position = "CEO",
                DirectPersonAddressEmail = "PjeterBla@gmail.com",
                DirectPhoneNumber = "789456123",
                CustomerRef = 1,
            };
            var model = _mapper.Map<CustomerContactInformactionForListVm>(contactCustomer);

            //Act
            _customerService.UpdateCustContact(model);

            //Assert
            _custContInfoRepo.Verify(r => r.UpdateCustContact(It.IsAny<CustomerContactInformaction>()), Times.Once());
        }
    }
}
