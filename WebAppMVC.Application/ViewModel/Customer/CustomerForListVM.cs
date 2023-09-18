using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class CustomerForListVM : IMapFrom<WebAppMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Customer, CustomerForListVM>();
        }
    }
}