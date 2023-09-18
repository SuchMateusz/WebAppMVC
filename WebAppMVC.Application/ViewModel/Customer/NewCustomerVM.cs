using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class NewCustomerVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string NIP { get; set; }

        public string PhoneNubmer { get; set; }

        public string AddressEmail { get; set; }
    }
}
