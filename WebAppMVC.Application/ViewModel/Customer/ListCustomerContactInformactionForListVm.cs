using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class ListCustomerContactInformactionForListVm
    {
        public List<CustomerContactInformactionForListVm> ContactCustomerInfo { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int CustomerId { get; set; }

        public int TotalCount { get; set; }
    }
}
