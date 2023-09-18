using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Customer;

namespace WebAppMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public int AddAddressModel(AddressForListVM address)
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(NewCustomerVM customer)
        {
            throw new NotImplementedException();
        }

        public int AddCustomerContactInformaction(CustomerContactInformactionForListVm custContactDetail)
        {
            throw new NotImplementedException();
        }

        public AddressForListVM GetAddressCustomerDetails(int customerId)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVM GetAllCustomerForList()
        {
            var customers = _customerRepo.GetAllActiveCustomers()
                .ProjectTo<CustomerForListVM>(_mapper.ConfigurationProvider).ToList();

            var customerList = new ListCustomerForListVM()
            {
                Customers = customers,
                TotalCount = customers.Count
            };
            //ListCustomerForListVM result = new ListCustomerForListVM();
            //result.Customers = new List<CustomerForListVM>();
            //foreach (var customer in customers)
            //{
            //    var custVM = new CustomerForListVM()
            //    {
            //        Id = customer.Id,
            //        Name = customer.Name,
            //        NIP = customer.NIP,
            //    };
            //    result.Customers.Add(custVM);
            //}
            //result.TotalCount = result.Customers.Count;

            return customerList;
        }

        public CustomerDetailsVM GetCustomerDetails(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            var customerVM = _mapper.Map<CustomerDetailsVM>(customer);
            customerVM.AddressDetails = new List<AddressForListVM>();
            foreach(var address in customer.AddressDetails)
            {
                var add = new AddressForListVM()
                {
                    BuildingNumber = address.BuildingNumber,
                    Street = address.Street,
                    ZipCode = address.ZipCode,
                    City = address.City,
                    Country = address.Country,
                };
                customerVM.AddressDetails.Add(add);
            }
            return customerVM;
        }
    }
}