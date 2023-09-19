using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class CustomerDetailsVM : IMapFrom<WebAppMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string NIP { get; set; }

        public string PhoneNubmer { get; set; }

        public string AddressEmail { get; set; }

        public List<CustomerContactInformactionForListVm> CustomerContactInformaction { get; set; }

        public List<AddressForListVM> AddressDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Customer, CustomerDetailsVM>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Login, opt => opt.MapFrom(s => s.LoginCustomer))
                .ForMember(d => d.NIP, opt => opt.MapFrom(s => s.NIP))
                .ForMember(d => d.PhoneNubmer, opt => opt.MapFrom(s => s.PhoneNubmer))
                .ForMember(d => d.AddressEmail, opt => opt.MapFrom(s => s.AddressEmail))
                .ForMember(d => d.CustomerContactInformaction, opt => opt.MapFrom(s => s.CustomerContactInformaction))
                .ForMember(d => d.AddressDetails, opt => opt.Ignore());
        }
    }
}