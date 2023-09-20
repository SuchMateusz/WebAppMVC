using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public int AddAddressModel(AddressForListVM address)
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(NewCustomerVM customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            int id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public int AddCustomerContactInformaction(CustomerContactInformactionForListVm custContactDetail)
        {
            throw new NotImplementedException();
        }

        public CustomerContactInformactionForListVm GetCustConDetails(int customerContactDetail)
        {
            var custContDetail = _customerRepo.GetCustomerContactInformactions();
            var custContDetailList = _mapper.Map<CustomerContactInformactionForListVm>(custContDetail);
            var customerList = new CustomerContactInformactionForListVm()
            {
                Name = custContDetailList.Name,
                LastNameUser = custContDetailList.LastNameUser,
                Position = custContDetailList.Position,
            };
            return customerList;
        }

        public AddressForListVM GetAddressCustomerDetails(int customerId)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVM GetAllCustomerForList(int pageSize, int pageNo, string searchString)
        {
            var customers = _customerRepo.GetAllActiveCustomers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<CustomerForListVM>(_mapper.ConfigurationProvider).ToList();
            var customersToShow = customers.Skip(pageSize*(pageNo-1)).Take(pageSize).ToList();
            var customerList = new ListCustomerForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Customers = customersToShow,
                TotalCount = customers.Count
            };
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