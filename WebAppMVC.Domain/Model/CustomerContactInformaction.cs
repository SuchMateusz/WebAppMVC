using System.ComponentModel;

namespace WebAppMVC.Domain.Model
{
    public class CustomerContactInformaction : EntityModel
    {
        public string LastNameUser { get; set; }

        public string Position { get; set; }

        public string DirectPersonAddressEmail { get; set; }

        public string DirectPhoneNumber { get; set; }

        public int CustomerRef { get; set; }

        public Customer Customer { get; set; }
    }
}