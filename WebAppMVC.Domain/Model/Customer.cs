using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebAppMVC.Domain.Model
{
    public class Customer : EntityModel
    {
        [DisplayName("Login")]
        public string LoginCustomer { get; set; }

        public string Password { get; set; }

        public string NIP { get; set; }

        public string PhoneNubmer { get; set; }

        public string AddressEmail { get; set; }

        public bool isActive { get; set; }

        public CustomerContactInformaction CustomerContactInformaction { get; set; }

        public virtual ICollection<Address> AddressDetails { get; set; }
    }
}