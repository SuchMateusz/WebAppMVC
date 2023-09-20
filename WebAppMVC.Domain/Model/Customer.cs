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

        public string PhoneNubmer { get; set; }

        public string AddressEmail { get; set; }

        public bool isActive { get; set; }

        public CustomerContactInformaction CustomerContactInformaction { get; set; }

        public virtual ICollection<Address> AddressDetails { get; set; }
    }
}