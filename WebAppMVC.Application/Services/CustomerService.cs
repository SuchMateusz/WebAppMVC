using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var adress = _mapper.Map<Address>(address);
            int id = _customerRepo.AddAddresses(adress);
            return id;
        }

        public int AddCustomer(NewCustomerVM customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            int id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public NewCustomerVM GetCustomerForEdit(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerForEdit = _mapper.Map<NewCustomerVM>(customer);
            return customerForEdit;
        }

        public AddressForListVM GetAddressForEdit(int id)
        {
            var address = _customerRepo.GetAddressById(id);
            var addressForEdit = _mapper.Map<AddressForListVM>(address);
            return addressForEdit;

        }

        public void UpdateCustomer(NewCustomerVM model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepo.UpdateCustomer(customer);
        }

        public void UpdateAddress(AddressForListVM model)
        {
            var address = _mapper.Map<Address>(model);
            _customerRepo.UpdateAddress(address);
        }

        public int AddCustomerContactInformaction(CustomerContactInformactionForListVm custContactDetail)
        {
            var custContactInforma = _mapper.Map<CustomerContactInformaction>(custContactDetail);
            int id = _customerRepo.AddCustomerContactInformaction(custContactInforma);
            return id;
        }

        public ListCustomerContactInformactionForListVm GetCustConDetails(int pageSize, int pageNo, int customerContactDetail)
        {
            var custContDetail = _customerRepo.GetCustomerContactInformactions().Where(p => p.CustomerRef == customerContactDetail)
                .ProjectTo<CustomerContactInformactionForListVm>(_mapper.ConfigurationProvider).ToList();
            var custContactToShow = custContDetail.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var custoContactList = new ListCustomerContactInformactionForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                ContactCustomerInfo = custContDetail,
                CustomerId = customerContactDetail,
                TotalCount = custContDetail.Count
            };
            return custoContactList;
        }

        public ListAddressForListVM GetAllAddressCustomer(int pageSize, int pageNo, int customerId)
        {
            var address = _customerRepo.GetAddresses().Where(p => p.CustomerId == customerId)
                .ProjectTo<AddressForListVM>(_mapper.ConfigurationProvider).ToList();
            var addressToShow = address.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var addressList = new ListAddressForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                CustomerId = customerId,
                Address = addressToShow,
                TotalCount = address.Count
            };
            return addressList;
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

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public CustomerContactInformactionForListVm GetCustContactForEdit(int id)
        {
            var custContact = _customerRepo.GetCustContactById(id);
            var contactForEdit = _mapper.Map<CustomerContactInformactionForListVm>(custContact);
            return contactForEdit;
        }

        public void UpdateCustContact(CustomerContactInformactionForListVm model)
        {
            var custContact = _mapper.Map<CustomerContactInformaction>(model);
            _customerRepo.UpdateCustContact(custContact);
        }
    }
}