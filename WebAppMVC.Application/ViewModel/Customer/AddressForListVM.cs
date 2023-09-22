using AutoMapper;
using FluentValidation;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class AddressForListVM
    {
        public string BuildingNumber { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public void Mapper (Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Customer, AddressForListVM>();
        }
    }
    public class NewAddressValidation : AbstractValidator<AddressForListVM>
    {
        public NewAddressValidation()
        {
            RuleFor(x => x.BuildingNumber).NotNull();
            RuleFor(x => x.BuildingNumber).MaximumLength(25);
            RuleFor(x => x.Street).Length(9, 14);
            RuleFor(x => x.ZipCode).NotEmpty();
            RuleFor(x => x.City).MaximumLength(150);
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}