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

        public void UpdateCustomer(NewCustomerVM model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepo.UpdateCustomer(customer);
        }

        public int AddCustomerContactInformaction(CustomerContactInformactionForListVm custContactDetail)
        {
            var custContactInforma = _mapper.Map<CustomerContactInformaction>(custContactDetail);
            int id = _customerRepo.AddCustomerContactInformaction(custContactInforma);
            return id;
        }

        public CustomerContactInformactionForListVm GetCustConDetails(int customerContactDetail)
        {
            var custContDetail = _customerRepo.GetCustomerContactInformactions().Where(p=>p.CustomerRef==customerContactDetail).
                ProjectTo<CustomerContactInformactionForListVm>(_mapper.ConfigurationProvider).ToList();
            var custContDetailList = _mapper.Map<CustomerContactInformactionForListVm>(custContDetail);
            var customerList = new CustomerContactInformactionForListVm()
            {
                Name = custContDetailList.Name,
                LastNameUser = custContDetailList.LastNameUser,
                Position = custContDetailList.Position,
                DirectPersonAddressEmail = custContDetailList.DirectPersonAddressEmail,
                DirectPhoneNumber = custContDetailList.DirectPhoneNumber,
                CustomerRef = custContDetailList.CustomerRef,
            };
            return customerList;
        }

        public List<AddressForListVM> GetAddressCustomerDetails(int customerId)
        {
            var address = _customerRepo.GetAddresses().Where(p => p.CustomerId == customerId)
                .ProjectTo<AddressForListVM>(_mapper.ConfigurationProvider).ToList();
            //var addressToListVM = _mapper.Map<AddressForListVM>(address);
            return address;
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
            //var address = GetAddressCustomerDetails(customerId);
            //customerVM.AddressDetails = new List<AddressForListVM>();
            //customerVM.AddressDetails.Add(address);
            //foreach (var addres in address)
            //{
            //    var add = new AddressForListVM()
            //    {
            //        BuildingNumber = addres.BuildingNumber,
            //        Street = addres.Street,
            //        ZipCode = addres.ZipCode,
            //        City = addres.City,
            //        Country = addres.Country,
            //    };
            //    customerVM.AddressDetails.Add(add);
            //}
            return customerVM;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }
    }
}