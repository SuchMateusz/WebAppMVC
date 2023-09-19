﻿using AutoMapper;

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
}