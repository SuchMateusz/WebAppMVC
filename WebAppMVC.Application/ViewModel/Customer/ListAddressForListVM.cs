using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class ListAddressForListVM
    {
        public List<AddressForListVM> Address { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int CustomerId { get; set; }

        public int TotalCount { get; set; }

    }
}
