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
    }
}