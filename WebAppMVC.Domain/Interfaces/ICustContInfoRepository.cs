using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface ICustContInfoRepository
    {
        public int AddCustomerContactInformaction(CustomerContactInformaction customerContactInformaction);

        public void DeleteCustomerContactInformaction(int customerContactInformactionId);

        public IQueryable<CustomerContactInformaction> GetCustomerContactInformactions();

        CustomerContactInformaction GetCustContactById(int id);

        void UpdateCustContact(CustomerContactInformaction custContact);
    }
}
