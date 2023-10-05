using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebAppMVC.Domain.Model
{
    public class Customer : EntityModel
    {
        public string Password { get; set; }

        public string NIP { get; set; }

        public string REGON { get; set; }

        public string PhoneNumber { get; set; }

        public string AddressEmail { get; set; }

        public bool isActive { get; set; }

        public ICollection<CustomerContactInformaction> CustomerContactInformaction { get; set; }

        public ICollection<Address> AddressDetails { get; set; }
    }
}