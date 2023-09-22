using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Interfaces
{
    public interface ICustomerRepository
    {
        public IQueryable<Customer> GetAllActiveCustomers();

        public int AddCustomer(Customer customer);

        public void DeleteCustomer(int customerId);

        public Customer GetCustomer(int customerId);

        public int AddCustomerContactInformaction (CustomerContactInformaction customerContactInformaction);

        public void DeleteCustomerContactInformaction(int customerContactInformactionId);

        public IQueryable<CustomerContactInformaction> GetCustomerContactInformactions();
        
        public int AddAddresses (Address address);

        public void DeleteAddresses (Address address);

        public IQueryable<Address> GetAddresses();
        void UpdateCustomer(Customer customer);
    }
}