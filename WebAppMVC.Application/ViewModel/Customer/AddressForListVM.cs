﻿using AutoMapper;
using FluentValidation;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class AddressForListVM : IMapFrom<Address>
    {
        public int Id { get; set; }

        public string BuildingNumber { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int CustomerId {  get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Address, AddressForListVM>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.BuildingNumber, opt => opt.MapFrom(s => s.BuildingNumber))
                .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Street))
                .ForMember(d => d.ZipCode, opt => opt.MapFrom(s => s.ZipCode))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country))
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                .ReverseMap();
        }
    }

    public class NewAddressValidation : AbstractValidator<AddressForListVM>
    {
        public NewAddressValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BuildingNumber).NotEmpty();
            RuleFor(x => x.BuildingNumber).MaximumLength(7);
            RuleFor(x => x.Street).Length(3, 30);
            RuleFor(x => x.ZipCode).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).MaximumLength(70);
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}