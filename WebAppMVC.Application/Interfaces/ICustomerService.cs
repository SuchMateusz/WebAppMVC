using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Customer;

namespace WebAppMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVM GetAllCustomerForList(int pageSize, int pageNo, string searchString);

        int AddCustomer (NewCustomerVM customer);

        NewCustomerVM GetCustomerForEdit(int id);

        int AddAddressModel (AddressForListVM address);

        ListAddressForListVM GetAllAddressCustomer(int pageSize, int pageNo, int customerId);

        int AddCustomerContactInformaction(CustomerContactInformactionForListVm custContactDetail);

        ListCustomerContactInformactionForListVm GetCustConDetails(int pageSize, int pageNo, int customerContactDetail);

        void DeleteCustomer(int id);

        void UpdateCustomer(NewCustomerVM model);

        public AddressForListVM GetAddressForEdit(int id);

        void UpdateAddress(AddressForListVM address);

        CustomerContactInformactionForListVm GetCustContactForEdit(int id);

        void UpdateCustContact(CustomerContactInformactionForListVm model);
    }
}