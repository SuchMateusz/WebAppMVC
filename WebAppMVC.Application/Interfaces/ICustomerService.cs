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

        AddressForListVM GetAddressCustomerDetails(int customerId);

        int AddCustomerContactInformaction(CustomerContactInformactionForListVm custContactDetail);

        CustomerContactInformactionForListVm GetCustConDetails(int customerContactDetail);

        CustomerDetailsVM GetCustomerDetails(int customerId);

        void DeleteCustomer(int id);

        void UpdateCustomer(NewCustomerVM model);
    }
}