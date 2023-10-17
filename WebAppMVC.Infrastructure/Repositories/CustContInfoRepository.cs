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
    public class CustContInfoRepository : ICustContInfoRepository
    {
        private readonly Context _context;

        public CustContInfoRepository (Context context)
        {
            _context = context;
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

        public CustomerContactInformaction GetCustContactById(int id)
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
