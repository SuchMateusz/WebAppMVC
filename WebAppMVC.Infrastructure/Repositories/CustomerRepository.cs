using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            customer.isActive = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).Property("Name").IsModified=true;
            _context.Entry(customer).Property("Password").IsModified = true;
            _context.Entry(customer).Property("NIP").IsModified = true;
            _context.Entry(customer).Property("REGON").IsModified = true;
            _context.Entry(customer).Property("PhoneNumber").IsModified = true;
            _context.Entry(customer).Property("AddressEmail").IsModified = true;
            _context.SaveChanges();
        }

        public int AddCustomerContactInformaction(CustomerContactInformaction customerContactInformaction)
        {
            _context.CustomerContactInformactions.Add(customerContactInformaction);
            _context.SaveChanges();
            return customerContactInformaction.Id;
        }

        public void DeleteCustomerContactInformaction(int customerContactInformactionId)
        {
            var customerContactInformaction = _context.CustomerContactInformactions.Find(customerContactInformactionId);
            _context.CustomerContactInformactions.Remove(customerContactInformaction);
        }

        public IQueryable<CustomerContactInformaction> GetCustomerContactInformactions()
        {
            var ContactInformaction = _context.CustomerContactInformactions;
            return ContactInformaction;
        }

        public int AddAddresses(Address address)
        {
            Customer customer;
            _context.Addresses.Add(address);
            customer = _context.Customers.FirstOrDefault(x => x.Id == address.CustomerId);
            if (customer != null)
            {
                customer.AddressDetails.Add(address);
            }

            _context.SaveChanges();
            return address.Id;
        }

        public void DeleteAddresses(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public IQueryable<Address> GetAddresses()
        {
            var addresses = _context.Addresses;
            return addresses;
        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            var customers = _context.Customers.Where(p=>p.isActive);
            return customers;
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            return customer;
        }

        public Address GetAddressById(int id)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);
            return address;
        }

        public void UpdateAddress(Address address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("BuildingNumber").IsModified = true;
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("ZipCode").IsModified = true;
            _context.Entry(address).Property("City").IsModified = true;
            _context.Entry(address).Property("Country").IsModified = true;
            _context.Entry(address).Property("CustomerId").IsModified = true;
            _context.SaveChanges();
        }

        public object GetCustContactById(int id)
        {
            var custContact = _context.CustomerContactInformactions.FirstOrDefault(x => x.Id == id);
            return custContact;
        }

        public void UpdateCustContact(CustomerContactInformaction custContact)
        {
            _context.Attach(custContact);
            _context.Entry(custContact).Property("Name").IsModified = true;
            _context.Entry(custContact).Property("LastNameUser").IsModified = true;
            _context.Entry(custContact).Property("Position").IsModified = true;
            _context.Entry(custContact).Property("DirectPersonAddressEmail").IsModified = true;
            _context.Entry(custContact).Property("DirectPhoneNumber").IsModified = true;
            _context.Entry(custContact).Property("CustomerRef").IsModified = true;
            _context.SaveChanges();
        }
    }
}