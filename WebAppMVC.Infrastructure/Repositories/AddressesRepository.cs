using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly Context _context;

        public AddressesRepository(Context context)
        {
            _context = context;
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
    }
}
