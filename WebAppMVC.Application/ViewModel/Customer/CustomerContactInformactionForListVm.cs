using AutoMapper;
using FluentValidation;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class CustomerContactInformactionForListVm : IMapFrom<CustomerContactInformaction>
    {
        public string Name { get; set; }

        public string LastNameUser { get; set; }

        public string Position { get; set; }

        public string DirectPersonAddressEmail { get; set; }

        public string DirectPhoneNumber { get; set; }

        public int CustomerRef {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.CustomerContactInformaction, CustomerContactInformactionForListVm>()
                .ForMember(s=>s.DirectPhoneNumber, opt => opt.MapFrom(s=> s.DirectPhoneNumber))
                .ForMember(s => s.DirectPersonAddressEmail, opt => opt.MapFrom(s=>s.DirectPersonAddressEmail))
                .ReverseMap();
        }

        public class CustomerContactInformactionValidation : AbstractValidator<CustomerContactInformactionForListVm>
        {
            public CustomerContactInformactionValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastNameUser).NotEmpty();
                RuleFor(x => x.Position).NotEmpty();
                RuleFor(x => x.DirectPersonAddressEmail).NotEmpty();
                RuleFor(x => x.DirectPhoneNumber).NotEmpty();

            }
        }
    }
}