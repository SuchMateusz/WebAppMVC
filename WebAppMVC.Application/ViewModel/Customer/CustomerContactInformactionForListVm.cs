using AutoMapper;
using FluentValidation;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class CustomerContactInformactionForListVm : IMapFrom<CustomerContactInformaction>
    {
        public int Id { get; set; }

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
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(s => s.LastNameUser, opt => opt.MapFrom(s => s.LastNameUser))
                .ForMember(s => s.Position, opt => opt.MapFrom(s => s.Position))
                .ForMember(s => s.CustomerRef, opt => opt.MapFrom(s => s.CustomerRef))
                .ReverseMap();
        }

        public class NewCustomerContactInformactionValidation : AbstractValidator<CustomerContactInformactionForListVm>
        {
            public NewCustomerContactInformactionValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Name).Length(2, 30);
                RuleFor(x => x.LastNameUser).NotEmpty();
                RuleFor(x => x.Position).NotEmpty();
                RuleFor(x => x.DirectPersonAddressEmail).NotEmpty();
                RuleFor(x => x.DirectPersonAddressEmail).EmailAddress();
                RuleFor(x => x.DirectPhoneNumber).NotEmpty();
                RuleFor(x => x.DirectPhoneNumber).MinimumLength(5);
            }
        }
    }
}