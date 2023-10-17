using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface IAddressesRepository
    {
        public int AddAddresses(Address address);

        public void DeleteAddresses(Address address);

        public IQueryable<Address> GetAddresses();

        Address GetAddressById(int id);

        void UpdateAddress(Address address);
    }
}
